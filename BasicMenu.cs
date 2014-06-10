using UnityEngine;
using System.Collections;

public class BasicMenu : MonoBehaviour {

	public bool GUIEnabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("n")) {
			GUIEnabled = !GUIEnabled;
		}
	}

	void OnGUI() {
		if(GUIEnabled) {
			if(GUI.Button (new Rect(Screen.width / 2, Screen.height / 2 - 40, 80, 20), "Help")) {
			
			}

			if(GUI.Button (new Rect(Screen.width / 2, Screen.height / 2 - 20, 80, 20), "Options")) {
				
			}

			if(GUI.Button (new Rect(Screen.width / 2, Screen.height / 2, 80, 20), "Exit")) {
				
			}
		}
	}
}
