using UnityEngine;
using System.Collections;

public class __GameManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 100), "r - Lose Health \n z, x , right mouse button - Camera Motion \n f - health potion");
		GUI.Label (new Rect(10, 100, 100, 100), "\n o - gain exp \n 1 - attack enemy \n m - lose mana \n n - menu");
	}
}
