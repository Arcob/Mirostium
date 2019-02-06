using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPortals : MonoBehaviour {
	public GameObject portal1;
	public GameObject portal2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnterRoom(){
		GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
		foreach(GameObject p in portals){
			p.SetActive(false);
		}
		portal1.SetActive(true);
		portal1.GetComponent<TextureSetup>().SetTexture();
		portal2.SetActive(true);
		portal2.GetComponent<TextureSetup>().SetTexture();
	}
}
