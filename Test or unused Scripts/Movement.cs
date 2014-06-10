using UnityEngine;
using System.Collections;

//adds a charactercontroller to the model
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {
	public float runMultiplier = 2;		//how fast the player runs
	public float moveSpeed = 5;			//the speed the character walks at
	public float strafeSpeed = 2.5f;
	//rotate speed
	public float rotateSpeed = 250;

	private Transform _myTransform;		//cached transform
	//reference player controler
	private CharacterController _controller;	//cached CharacterController


	void Awake(){
		//assigning
		_myTransform = transform;
		_controller = GetComponent<CharacterController> ();
	}

	// Use this for initialization
	void Start () {
		//tells all animations to loop
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_controller.isGrounded) {
			_controller.Move(Vector3.down * Time.deltaTime);
		}
		Turn();
		Walk();
		Strafe();

	}

	private void Turn() {
		//looking for absolute value to determine movement
		//checks if rotate player from input manager is pressed
		//- when a is pressed + when d is pressed
		if (Mathf.Abs (Input.GetAxis ("Rotate Player")) > 0) {
			//			Debug.Log("Rotate: " + Input.GetAxis ("Rotate Player"));
			// times by deltatime to keep it smooth, times by rotate speed dont want to rotate on x or y
			_myTransform.Rotate(0, Input.GetAxis ("Rotate Player") * Time.deltaTime * rotateSpeed, 0);
		}
	}

	private void Walk() {
		if (Mathf.Abs (Input.GetAxis ("Move Forward")) > 0) {
			if(Input.GetButton("Run")) {
				Debug.Log ("Running");
				animation.CrossFade("run");
				_controller.SimpleMove (_myTransform.TransformDirection (Vector3.forward) * Input.GetAxis ("Move Forward") * moveSpeed * runMultiplier);

			}else {
				animation.CrossFade("walk1");
//				animation["walk1"].speed = 2;
				_controller.SimpleMove (_myTransform.TransformDirection (Vector3.forward) * Input.GetAxis ("Move Forward") * moveSpeed);
			}
		}
		else {
			animation.CrossFade("idle2");
		}

	}

	private void Strafe() {
		if (Mathf.Abs (Input.GetAxis ("Strafe")) > 0) {
			//			Debug.Log("Strafe: " + Input.GetAxis ("Strafe"));
			animation.CrossFade("side");

			_controller.SimpleMove (_myTransform.TransformDirection (Vector3.right) * Input.GetAxis ("Strafe") * strafeSpeed);
		}

	}
}
