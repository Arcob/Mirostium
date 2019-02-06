Shader "Custom/DrawSimple"
{
    SubShader 
    {
        ZWrite Off
        ZTest Always
        Lighting Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            struct a2v {
                float4 pos: POSITION;
            };

            struct v2f {
			    float4 pos : SV_POSITION;
			};
 
            //just get the position correct
            v2f vert(a2v v)
            {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.pos);
                return o;
            }
 
            //return white
            float4 frag() : COLOR
            {
                return float4(1.0, 0, 1.0, 1.0);
            }
 
            ENDCG
        }
    }
}