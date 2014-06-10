using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			BasicInventory.inventoryArray[0]++;
			Destroy (gameObject);
		}
	}
}
