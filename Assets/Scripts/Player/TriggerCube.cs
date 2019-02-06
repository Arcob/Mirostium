using System.Collections.Generic;
using UnityEngine;

public class TriggerCube : MonoBehaviour {
	private List<Item> itemList = new List<Item>();

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Item")){
			itemList.Add(other.gameObject.GetComponent<Item>());
			other.gameObject.GetComponent<Item>().OnTriggerIn();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Item")){
			itemList.Remove(other.gameObject.GetComponent<Item>());
			other.gameObject.GetComponent<Item>().OnTriggerOut();
		}
	}

	public void ClearItemList(){
		itemList.Clear();
	}

	public List<Item> GetItemList(){
		return itemList;
	}
}
