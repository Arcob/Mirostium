using UnityEngine;

public class GameObjectEvents : MonoBehaviour
{

    public static event System.Action<GameObject, string> notifyAwake;
    public static event System.Action<GameObject, string> notifyDeath;

    void Start()
    {
        //Notify if any listeners are present about its awake status
        if (notifyAwake != null)
		{
            SceneController sc = SceneController.Instance;
            notifyAwake(gameObject, sc.scenes[sc.index]);
		}
    }

    void OnDestroy()
    {
        // tell any listeners if present that this gameobject is dying
        if (notifyDeath != null)
		{
            SceneController sc = SceneController.Instance;
            notifyDeath(gameObject, sc.scenes[sc.index]);
		}
    }

}