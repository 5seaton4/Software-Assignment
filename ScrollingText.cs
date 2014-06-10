using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour {

	public float letterPause = 0.2f;
	public AudioClip sound;

	public string myText = "Test of scrolling text" + "\n" + "teeessstttttt";

	// Use this for initialization
	void Start () {
		TypeText ();
		StartCoroutine("TypeText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator TypeText() {
//		for (int i = 0; i < myText.Length;i++) {
		foreach(char c in myText) {
			guiText.text += c;
			if(sound)
				audio.PlayOneShot(sound);
			yield return new WaitForSeconds(letterPause);
		}
	}
}
