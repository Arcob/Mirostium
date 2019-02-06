using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject portalPrefab;

    public GameObject SetPortal(GameObject p1, GameObject p2)
    {
        var config1 = p1.GetComponent<PortalConfig>();
        var config2 = p2.GetComponent<PortalConfig>();
        var portal = Instantiate(portalPrefab) as GameObject;
        var sender = portal.transform.FindChild("Sender");
        var receiver = portal.transform.FindChild("Receiver");
        
        sender.transform.position = p1.transform.position;
        sender.transform.rotation = p1.transform.rotation;
        sender.transform.localScale = new Vector3(config1.width, config1.height, 1);
        receiver.transform.position = p2.transform.position;
        receiver.transform.rotation = p2.transform.rotation;
        receiver.transform.localScale = new Vector3(config2.width, config2.height, 1);
        var portalCamera = receiver.GetComponentInChildren<PortalCamera>();
        portalCamera.playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        portal.SetActive(true);
        return portal;
    }
}
