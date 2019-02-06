using UnityEngine;

public class SimpleFollow : MonoBehaviour {

	public Transform player;
	public float threshold = 5;
	private Vector3 offset;
	[RangeAttribute(0, 1)]
	public float scale = 1;

	void Start () {
			offset = transform.position - player.transform.position;
			transform.position = player.position + offset;
	}
	
	/// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// It is called after all Update functions have been called.
	/// </summary>
	void LateUpdate()
	{
		transform.position = player.position + offset * scale;
		transform.LookAt(player);		
	}
}
