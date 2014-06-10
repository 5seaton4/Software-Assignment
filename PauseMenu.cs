using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private bool pause;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p") && pause == false) {
			pause = true;
			Time.timeScale = 0;
		}
		else if(Input.GetKeyDown("p") && pause == true) {
			pause = false;
			Time.timeScale = 1;
		}
	}
}
