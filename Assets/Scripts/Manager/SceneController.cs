using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PortalController))]
[RequireComponent(typeof(LiveOnLoad))]
public class SceneController : MonoBehaviour {
    public static SceneController Instance {get; private set;}
    public GameObject directLight;
    public string[] scenes;
    public int index;
    public string currentScene;

    PortalController portalController;
    GameObject oldPortal;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        portalController = GetComponent<PortalController>();
        index = 0;
        // load first scene before start
        if (scenes.Length > 0)
        {
            currentScene = scenes[index];
            SceneManager.LoadScene(scenes[index], LoadSceneMode.Additive);
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine("_LoadNextScene");
    }

    public void UnLoadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    IEnumerator _LoadNextScene()
    {
        if (index < scenes.Length - 1)
        {
            index++;
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(scenes[index], LoadSceneMode.Additive);
            if (index-2 >= 0)
            {
                SceneManager.UnloadSceneAsync(scenes[index - 2]);
            }
            while (!asyncOp.isDone)
            {
                yield return null;
            }
            GameObject p1;
            GameObject p2;
            FindPortalPoint(out p1, out p2);
            if (p1 != null && p2 != null)
            {
                if (oldPortal != null)
                {
                    DestroyObject(oldPortal);
                }
                oldPortal = portalController.SetPortal(p1, p2);
            }
        }
    }

    void FindPortalPoint(out GameObject p1, out GameObject p2)
    {
        p1 = null;
        p2 = null;
        List<GameObject> objList1 = GameObjectEventsHandler.specificSceneObjects[scenes[index-1]];
        foreach (var obj in objList1)
        {
            if (obj.CompareTag("SenderPoint"))
            {
                p1 = obj;
                break;
            }
        }
        List<GameObject> objList2 = GameObjectEventsHandler.specificSceneObjects[scenes[index]];
        foreach (var obj in objList2)
        {
            if (obj.CompareTag("ReceiverPoint"))
            {
                p2 = obj;
                break;
            }
        }
    }
}
