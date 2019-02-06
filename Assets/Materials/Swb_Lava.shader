// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Swb_Lava" {
	Properties {
		_Color ("Main Color", Color) = (0, 0.15, 0.115, 1)
		_MainTex1 ("Base (RGB)", 2D) = "white" {}
		_MainTex2 ("Base (RGB)", 2D) = "white" {}
		_WaveMap ("Wave Map", 2D) = "bump" {}
		_BumpScale ("Bump Scale", Float) = 1.0
		_TransScale ("Trans Scale", Float) = 0.5
		_WaveXSpeed ("Wave Horizontal Speed", Range(-0.1, 0.1)) = 0.01
		_WaveYSpeed ("Wave Vertical Speed", Range(-0.1, 0.1)) = 0.01
	}
	SubShader {
		// We must be transparent, so other objects are drawn before this one.
		Tags { "Queue"="Transparent" "RenderType"="Opaque" }
		
		Pass {
			Tags { "LightMode"="ForwardBase" }
			
			CGPROGRAM
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			
			#pragma multi_compile_fwdbase
			
			#pragma vertex vert
			#pragma fragment frag
			
			fixed4 _Color;
			sampler2D _MainTex1;
			float4 _MainTex1_ST;
			sampler2D _MainTex2;
			float4 _MainTex2_ST;
			sampler2D _WaveMap;
			float4 _WaveMap_ST;
			float _BumpScale;
			float _TransScale;
			fixed _WaveXSpeed;
			fixed _WaveYSpeed;
			
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT; 
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float4 scrPos : TEXCOORD0;
				float4 uv : TEXCOORD1;
				float4 TtoW0 : TEXCOORD2;  
				float4 TtoW1 : TEXCOORD3;  
				float4 TtoW2 : TEXCOORD4; 
				float4 wave : TEXCOORD5;
			};
			
			v2f vert(a2v v) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				
				o.scrPos = ComputeGrabScreenPos(o.pos);
				
				o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex1);
				o.uv.zw = TRANSFORM_TEX(v.texcoord, _MainTex2);

				o.wave.xy = TRANSFORM_TEX(v.texcoord, _WaveMap);
				
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;  
				fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);  
				fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);  
				fixed3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w; 
				
				o.TtoW0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);  
				o.TtoW1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);  
				o.TtoW2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);  
				
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				float3 worldPos = float3(i.TtoW0.w, i.TtoW1.w, i.TtoW2.w);
				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(worldPos));
				float2 speed = _Time.y * float2(_WaveXSpeed, _WaveYSpeed);
				
				// Get the normal in tangent space
				fixed3 bump1 = normalize(UnpackNormal(tex2D(_WaveMap, i.wave.xy + speed)).rgb);
				fixed3 bump2 = normalize(UnpackNormal(tex2D(_WaveMap, i.wave.xy - speed)).rgb);

				bump1.xy *= _BumpScale;
				bump1.z = sqrt(1.0 - saturate(dot(bump1.xy,bump1.xy)));

				bump2.xy *= _BumpScale;
				bump2.z = sqrt(1.0 - saturate(dot(bump2.xy,bump2.xy)));
				// Convert the normal to world space
				bump1 = normalize(half3(dot(i.TtoW0.xyz, bump1), dot(i.TtoW1.xyz, bump1), dot(i.TtoW2.xyz, bump1)));
				bump2 = normalize(half3(dot(i.TtoW0.xyz, bump2), dot(i.TtoW1.xyz, bump2), dot(i.TtoW2.xyz, bump2)));
				
				fixed4 texColor1 = tex2D(_MainTex1, i.uv.xy + speed);
				fixed4 bumpedTex1 = texColor1 * (max(0, dot(bump1, viewDir))/3+0.67);

				fixed4 texColor2 = tex2D(_MainTex2, i.uv.xy + speed);
				fixed4 bumpedTex2 = texColor2 * (max(0, dot(bump2, viewDir))/3+0.67);

				fixed3 finalColor = bumpedTex1.rgb * _TransScale + bumpedTex2 * (1- _TransScale);
				
				return fixed4(finalColor, 1);
			}
			
			ENDCG
		}
	}
	// Do not cast shadow
	FallBack Off
}
