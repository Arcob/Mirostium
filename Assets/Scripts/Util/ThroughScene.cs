using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThroughScene : MonoBehaviour {
	bool loadFlag = false;
	bool unloadFlag = false;
	public bool shouldLoad = false;
	public bool shouldOpenLight = true;
	public bool shouldUnload = false;
	public string sceneName;
	public string unloadScene = null;
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneController.Instance.currentScene = sceneName;
			if (shouldLoad && !loadFlag)
			{
				loadFlag = true;
				SceneController.Instance.LoadNextScene();
				SettingEnvironment env = GetComponent<SettingEnvironment>();
				if (env != null)
				{
					env.ApplySetting();					
				}
			}
			if (shouldOpenLight)
			{
				SceneController.Instance.directLight.GetComponent<Light>().enabled = true;
			}
			if (shouldUnload && !unloadFlag)
			{
				unloadFlag = true;
				SceneController.Instance.UnLoadScene(unloadScene);
			}
		}
	}
}
