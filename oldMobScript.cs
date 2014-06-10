using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

	public float speed;
	public float range;


	public Transform player;
	public CharacterController controller;
	private Fighter opponent;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip die;
	public AnimationClip attackClip;

	public float impactTime = 0.38f;

	private int health;

	private bool impacted;

	public int damage;

	// Use this for initialization
	void Start () {
		health = 100;
		opponent = player.GetComponent<Fighter> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(!IsDead()) {

			if(!InRange()) {
				Chase ();
			}
			else {
				animation.Play (attackClip.name);
				Attack ();
				if(animation[attackClip.name].time > 0.9 * animation[attackClip.name].length) {
					impacted = false;
				}
			}
//			Debug.Log (health);
		}
		else {
			DieMethod();
		}
	}

	void Attack() {
		if(animation[attackClip.name].time > animation[attackClip.name].length * impactTime && !impacted && animation[attackClip.name].time < 0.9 * animation[attackClip.name].length) {
			opponent.GetHit(damage);
			impacted = true;
		}
	}

	bool InRange() {
		if (Vector3.Distance (transform.position, player.position) < range) {
			return true;
		}
		else {
			return false;
		}
	}

	public void GetHit(int damage) {
		health = health - damage;
		if(health < 0) {
			health = 0;
		}
	}

	void Chase() {
		transform.LookAt (player.position);
		controller.SimpleMove (transform.forward * speed);
		animation.CrossFade (run.name);
	}

	void DieMethod() {
		animation.Play (die.name);
		if(animation[die.name].time > animation[die.name].length * 0.9) {
			Destroy (gameObject);
		}
	}
	bool IsDead() {
		if (health <= 0) {
			return true;
		}
		else {
			return false;
		}
	}

	void OnMouseOver() {
		player.GetComponent<Fighter>().opponent = gameObject;
	}
}
