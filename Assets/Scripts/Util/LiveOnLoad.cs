using UnityEngine;

public class LiveOnLoad : MonoBehaviour
{
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
