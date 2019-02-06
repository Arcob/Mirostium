using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour {

    public bool lightOn;

    public void Start()
    {
        if (lightOn)
        {
            var light = transform.FindChild("Point light");
            light.gameObject.SetActive(true);
        }
    } 

}
