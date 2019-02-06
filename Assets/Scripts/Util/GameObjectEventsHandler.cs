using UnityEngine;
using System.Collections.Generic;

public class GameObjectEventsHandler : MonoBehaviour 
{
    //Dictionary of specific scene gameobjects
    public static Dictionary<string, List<GameObject>> specificSceneObjects {get; private set;}

    void Awake()
    {
        specificSceneObjects = new Dictionary<string, List<GameObject>>();
    }

    void OnEnable()
    {
        GameObjectEvents.notifyAwake += HandlenotifyAwake;
        GameObjectEvents.notifyDeath += HandlenotifyDeath;
    }

    void OnDisable()
    {
        GameObjectEvents.notifyAwake -= HandlenotifyAwake;
        GameObjectEvents.notifyDeath -= HandlenotifyDeath;
    }

    void HandlenotifyAwake (GameObject obj, string sceneName)
    {
        //if there are no objects for this scene then create a new list with the current scene list name
        if(!specificSceneObjects.ContainsKey(sceneName))
            specificSceneObjects.Add(sceneName, new List<GameObject>());

        //now add the gameobject which sent this event upon awake/start to this list
        specificSceneObjects[sceneName].Add(obj);
    }

    void HandlenotifyDeath (GameObject obj, string sceneName)
    {
        //if the dicitonary has this object then remove it upon object destroy
        if(specificSceneObjects.ContainsKey(sceneName))
        {
            if(specificSceneObjects[sceneName].Contains(obj))
                specificSceneObjects[sceneName].Remove(obj);
        }
    }
}