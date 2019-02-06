using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoStairsController : MonoBehaviour {

	Animator anim;
	int level = 0;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void SetLevel(int x)
	{
		level = x;
		anim.SetInteger("Level", x);
	}

	public void RemoveLevel(int x)
	{
		if (level == x)
		{
			SetLevel(0);
		}
	}

	public void OpenPortal()
	{
		SceneController.Instance.LoadNextScene();
	}

}
