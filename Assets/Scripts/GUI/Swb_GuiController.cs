using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swb_GuiController : MonoBehaviour {

	public Canvas canvas;

	public void onQuitButtonClick(){
		Debug.Log("Quit");
		canvas.gameObject.SetActive(false);
		Application.Quit();
	}

	public void onStartButtonClick(){
		canvas.gameObject.SetActive(false);
		GameObject.FindWithTag("Player").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
		Camera.main.gameObject.GetComponent<CameraFollow>().ChangePosition(4f, 5.6f, 4.0f,2.0f);
		Debug.Log("start");
	}
}
