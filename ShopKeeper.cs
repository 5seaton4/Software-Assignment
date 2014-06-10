using UnityEngine;
using System.Collections;

public class ShopKeeper : MonoBehaviour {

	public RaycastHit hit;

	public bool shopOpen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && collider.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
			//enable Shop
			shopOpen = true;
		}
	}

	void OnGUI() {
		if (shopOpen == true) {
			if(GUI.Button(new Rect(10, 70, 50, 30), "Item 1")) {
				Debug.Log ("You bought an item");
			}
		}
	}
}
