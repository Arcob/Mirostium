using UnityEngine;

public class Box : Item {

	public override void Operate()
	{
		Debug.Log(this.name+" operate");
		//gameObject.SetActive(false);
	}
}
