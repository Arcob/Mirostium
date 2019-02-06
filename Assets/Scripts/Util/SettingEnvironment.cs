using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingEnvironment : MonoBehaviour {

	public Material skybox;

	public void ApplySetting()
	{
		RenderSettings.skybox = skybox;
		RenderSettings.ambientMode = AmbientMode.Skybox;
		RenderSettings.ambientIntensity = 1;
	}
}
