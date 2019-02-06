using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
	public Transform target;
	public float speed = 10;

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		transform.RotateAround(target.position, Vector3.up, 10 * Time.deltaTime);
	}
}
