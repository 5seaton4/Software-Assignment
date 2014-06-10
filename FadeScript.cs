using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 2.0f;

	public float drawDepth = -1000f;
	public bool alphaWait = true;

	private float alpha = 1.0f;
	private float fadeDir = -1f;

	// Use this for initialization
	void Start () {
		StartCoroutine("FadeIn");
		alpha = 1;
		FadeIn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (alphaWait == false) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
		}

		alpha = Mathf.Clamp01 (alpha);

		Color thisColor = GUI.color;
		thisColor.a = alpha;
		GUI.color = thisColor;
		GUI.depth = (int)drawDepth;

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);

	}

	IEnumerator FadeIn() {
		yield return new WaitForSeconds(2);
		alphaWait = false;

		fadeDir = -1;
	}

	void fadeOut() {
		fadeDir = 1;
	}
}
