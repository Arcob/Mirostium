using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private TriggerCube triggerCube;
	// Use this for initialization
	void Start ()
	{
		triggerCube = GetComponentInChildren<TriggerCube>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Touch"))
		{
			foreach (var item in triggerCube.GetItemList())
			{
				item.Operate();
			}
		}
	}
}
