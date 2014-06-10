using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class HoveringText : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	public bool clampToScreen = false;
	public float clampBorderSize = 0.05f;
	public bool useMainCamera = true;
	public Camera cameraToUse;

	public Vector3 relativePosition;

	private Camera cam;
	private Transform thisTransform;
	private Transform camTransform;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		if (useMainCamera) {
			cam = Camera.main;
		}
		else {
			cam = cameraToUse;
		}
		camTransform = cam.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(clampToScreen) {
			relativePosition = camTransform.InverseTransformPoint(target.position);
			relativePosition.z = Mathf.Max(relativePosition.z, 1.0f);
			thisTransform.position = cam.WorldToViewportPoint(camTransform.TransformPoint(relativePosition + offset));
			thisTransform.position = new Vector3(Mathf.Clamp(thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize), Mathf.Clamp(thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize), thisTransform.position.z);
		}
		else {
			thisTransform.position = cam.WorldToViewportPoint(target.position + offset);
		}
	}
}
