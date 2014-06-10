using UnityEngine;
using System.Collections;

public class NewCursor : MonoBehaviour {

	public Texture2D yourCursor;
	public int cursorSizeX = 16;
	public int cursorSizeY = 16;

	// Use this for initialization
	void Start () {
		//need to change cursor in camera script
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), yourCursor);
	}
}
