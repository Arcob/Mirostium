using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchController : MonoBehaviour {

	public Animator LogoAnim;
	public string initSceneName = "Init";
	public void ShowLogo()
	{
		if (LogoAnim != null)
		{
			LogoAnim.SetTrigger("ShowLogo");
		}
		else
		{
			Debug.Log("no Animator!!");
		}
	}

	public void LoadStart()
	{
		SceneManager.LoadSceneAsync(initSceneName);
	}
}
