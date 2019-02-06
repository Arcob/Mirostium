using UnityEngine;

public abstract class Item : MonoBehaviour {

    int originLayer;

    void Start()
    {
        originLayer = gameObject.layer;
    }

    public void OnTriggerIn()
    {
        gameObject.layer = LayerMask.NameToLayer("Outline");
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Outline");
            foreach (Transform grandson in child)
            {
                grandson.gameObject.layer = LayerMask.NameToLayer("Outline");
            }
        } // Outline deep to 2 level child
          // Don't restore to the original mask
          // FIXME dirty implemtation
    }

	public void OnTriggerOut()
    {
        gameObject.layer = originLayer;
        foreach (Transform child in transform)
        {
            child.gameObject.layer = originLayer;
            foreach (Transform grandson in child)
            {
                grandson.gameObject.layer = originLayer;
            }
        }
    }
	public abstract void Operate();
}
