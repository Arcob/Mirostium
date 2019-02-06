using UnityEngine;

public class EyeBehavior : MonoBehaviour {

    private GameObject player;

	void Start () 
	{
        player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () 
	{
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);
	}

    public void SetEye(bool isOpened)
    {
        var closed = transform.FindChild("eye_closed");
        var open = transform.FindChild("eye_opened");
        closed.gameObject.SetActive(!isOpened);
        open.gameObject.SetActive(isOpened);
    }
}
