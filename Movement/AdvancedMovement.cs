using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class AdvancedMovement : MonoBehaviour {

	//Mob

	//run, jump, fall, idle


	public enum State {
		Idle,
		Init,
		Setup,
		Run
	}

	public enum Turn {
		left = -1,
		none = 0,
		right = 1
	}
	public enum Forward {
		back = -1,
		none = 0,
		forward = 1
	}

	public float runMultiplier = 2;		//how fast the player runs
	public float walkSpeed = 3;			//the speed the character walks at
	public float strafeSpeed = 2.5f;
	//rotate speed
	public float rotateSpeed = 250;
	public float gravity = 20;			// the seetting for gravity
	public float airTime = 0;			// how long have we been in the air since last time we touched the ground
	public float fallTime = .5f;		//the length of time we have to be falling bewfore the system knows its a fall
	public float jumpHeight = 8;		//how high you can jump.
	public float jumpTime = 1.5f;

	public static bool attack;
	public static bool die;

	public CollisionFlags _collisionFlags;	//the collison flags we have from the last frame
	private Vector3 _moveDirection;		//this is the direction our character is moving.
	private Transform _myTransform;		//cached transform
	private CharacterController _controller;	//cached CharacterController

	private Turn _turn;
	private Forward _forward;
	private Turn _strafe;
	private bool _run;
	private bool _jump;

	private State _state;

	void Awake(){
		//assigning
		_myTransform = transform;
		_controller = GetComponent<CharacterController> ();

		_state = AdvancedMovement.State.Init;
	}

	// Use this for initialization
	IEnumerator Start () {
		while(true) {
			switch(_state) {
			case State.Init:
				Init();
				break;
			case State.Setup:
				Setup();
				break;
			case State.Run:
				ActionPicker();
				break;
			}

			yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!attack && !die) {
		}
	}

	private void Init() {
		if(!GetComponent<CharacterController>()) return;
		if(!GetComponent<Animation>()) return;

		_state = AdvancedMovement.State.Setup;
	}

	private void Setup() {
		_moveDirection = Vector3.zero;
		animation.Stop ();
		animation.wrapMode = WrapMode.Loop;
		animation ["jump"].layer = 1;
		animation ["jump"].wrapMode = WrapMode.Once;
		animation.Play ("idle2");
		

		_turn = AdvancedMovement.Turn.none;
		_forward = AdvancedMovement.Forward.none;
		_strafe = AdvancedMovement.Turn.none;
		_run = true;
		_jump = false;

		_state = State.Run;
	}


	private void ActionPicker() {

			// times by deltatime to keep it smooth, times by rotate speed dont want to rotate on x or y
		_myTransform.Rotate(0, (int)_turn * Time.deltaTime * rotateSpeed, 0);

		//if we are on the ground let us move
		if (_controller.isGrounded) {
			//				Debug.Log("On the Ground");
			//reset air timer if we are on the ground
			airTime = 0;
			
			//get the user input if we should be moving forward or sideways
			//we will calculate a new Vector3 for where the player needs to be
			_moveDirection = new Vector3((int)_strafe, 0, (int)_forward);
			_moveDirection = _myTransform.TransformDirection(_moveDirection).normalized;
			_moveDirection *= walkSpeed;
			
			if(_forward != Forward.none) {					//if user is pressing forward
				if(_run){							//and pressing the run key
					_moveDirection *= runMultiplier;				//move user at run speed
					Run ();											//play run animation
				}

				else {
					Walk ();										//play walk animation
				}
			}
			else if(_strafe != AdvancedMovement.Turn.none) {
				Strafe ();
				
			}
			else {
				Idle ();											//play idle animation
			}
			
			
			if(_jump) {							//if the user pressed the jump key
				if(airTime < jumpTime) {							// if we have not already been in the air to long
					_moveDirection.y += jumpHeight;					//move them upwards
					Jump ();										//play jump animation
					_jump = false;
				}
			}
			
		}
		else {
			//				Debug.Log("Not on the Ground");
			
			if((_collisionFlags & CollisionFlags.CollidedBelow) == 0) {
				airTime += Time.deltaTime;
				if(airTime > fallTime) {
					Fall();
				}
			}
		}
		
		
		_moveDirection.y -= gravity * Time.deltaTime;

		_collisionFlags = _controller.Move (_moveDirection * Time.deltaTime);


	}

	public void MoveMeForward(Forward z) {
		_forward = z;
	}

	public void ToggleRun() {
		_run = !_run;
	}

	public void RotateMe(Turn y) {
		_turn = y;
	}

	public void Strafe(Turn x) {
		_strafe = x;
	}

	public void JumpUp() {
		_jump = true;
	}

	public void Idle() {
		animation.CrossFade ("idle2");
	}

	public void Walk() {
		animation.CrossFade ("walk1");
	}

	public void Run() {
		animation ["run"].speed = 1.5f;
		animation.CrossFade ("run");
	}

	public void Jump() {
		animation.CrossFade ("jump");
	}

	public void Strafe() {
		animation.CrossFade ("side");
	}

	public void Fall() {
		animation.CrossFade ("fall");
	}
}
