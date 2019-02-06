using UnityEngine;
using System.Collections;

public class AutoStairsTrigger : MonoBehaviour
{
	public int level = 1;
	public AutoStairsController controller;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (controller != null)
			{
				controller.SetLevel(level);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (controller != null)
			{
				StartCoroutine("DeferLeave");
			}
		}
	}
	
	IEnumerator DeferLeave()
	{
		yield return new WaitForSeconds(0.5f);
		controller.RemoveLevel(level);
		yield return null;
	}
}
