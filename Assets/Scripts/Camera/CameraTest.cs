using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

	public CameraFollow CameraFollow;
	public float height = 0;
	public float distance = 0;
	
	// Update is called once per frame
	void Update () {
		if (CameraFollow != null)
		{
			CameraFollow.ChangePosition(height,distance,1);
		}
	}
}
