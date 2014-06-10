using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AdvancedMovement))]
[RequireComponent(typeof(SphereCollider))]
public class AI : MonoBehaviour {

	public float baseMeleeRange = 3.5f;
	public Transform target;

	private Transform _myTransform;

	private const float ROTATION_DAMP = .03f;
	private const float FORWARD_DAMP = .9f;

	// Use this for initialization
	void Start () {
		_myTransform = transform;
		GameObject go = GameObject.FindGameObjectWithTag("Player");

		if(go == null) {
			Debug.LogError("Could not find the player");
		}


		target = go.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if(target) {
			Vector3 dir = (target.position - _myTransform.position).normalized;
			float direction = Vector3.Dot(dir, transform.forward);

			float dist = Vector3.Distance(target.position, _myTransform.position);

			Debug.Log(dist);
			if(direction > FORWARD_DAMP && dist > baseMeleeRange) {
				SendMessage("MoveMeForward", AdvancedMovement.Forward.forward);
			}
			else {
				SendMessage("MoveMeForward", AdvancedMovement.Forward.none);
				
			}

			dir = (target.position - _myTransform.position).normalized;
			direction = Vector3.Dot(dir, transform.right);

			if(direction > ROTATION_DAMP) {
				SendMessage("RotateMe", AdvancedMovement.Turn.right);

			}
			else if(direction < -ROTATION_DAMP) {
				SendMessage("RotateMe", AdvancedMovement.Turn.left);

			}
			else {
				SendMessage("RotateMe", AdvancedMovement.Turn.none);
			}
		}
	}
}
