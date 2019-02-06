using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour {
	public Shader postOutline;
	public Shader drawSimple;
	Material postMat;
	Camera attachedCamera;
	Camera tempCam;
	void Start()
	{
		attachedCamera = GetComponent<Camera>();
		tempCam = new GameObject("PostEffectCamera").AddComponent<Camera>();
        tempCam.enabled = false;
		postMat = new Material(postOutline);
	}

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		tempCam.CopyFrom(attachedCamera);
		tempCam.clearFlags = CameraClearFlags.Color;
		tempCam.backgroundColor = Color.black;
		tempCam.cullingMask = 1 << LayerMask.NameToLayer("Outline");
		RenderTexture tempRt = new RenderTexture(src.width, src.height, 0, RenderTextureFormat.R8);
		tempRt.Create();
		tempCam.targetTexture = tempRt;
		tempCam.RenderWithShader(drawSimple, "");
		Graphics.Blit(tempRt, dest, postMat);
		tempRt.Release();
	}
}
