using UnityEngine;

public class LoadTest : MonoBehaviour {
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneController.Instance.LoadNextScene();
        }
    }
}
