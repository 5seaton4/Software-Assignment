using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {
	public AudioClip footsteps;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Move Forward")) {
			audio.clip = footsteps;
			audio.Play();
		}
		if (Input.GetButtonUp ("Move Forward")) {
			audio.Stop();
		}
	}
}
