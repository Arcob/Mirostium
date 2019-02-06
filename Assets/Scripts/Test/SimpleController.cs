using UnityEngine;

public class SimpleController : MonoBehaviour {

	public float speed = 1;
	public Transform respawn = null;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		if (respawn != null)
		{
			transform.position = respawn.position;			
		}
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
			rb.velocity = Vector3.left * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
			rb.velocity = Vector3.right * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
	}
}
