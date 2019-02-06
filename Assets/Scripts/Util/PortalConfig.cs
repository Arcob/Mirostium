using UnityEngine;

public class PortalConfig : MonoBehaviour {
	[RangeAttribute(0, 50)]
	public float width = 1;
	[RangeAttribute(0, 50)]
	public float height = 1;

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}
