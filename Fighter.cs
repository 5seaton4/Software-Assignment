using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	public GameObject opponent;
	public AnimationClip attack;
	public AnimationClip dieClip;
	public int damage;
	public float impactTime;
	public bool impacted;

	public float range;

	bool started;
	bool ended;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (opponent);
		if(Input.GetKey(KeyCode.L) && InRange()) {
			animation.CrossFade(attack.name);
			AdvancedMovement.attack = true;
			animation.wrapMode = WrapMode.Once;

			if(opponent != null) {
				transform.LookAt(opponent.transform.position);
			}
		}

		if(animation[attack.name].time > 0.9 * animation[attack.name].length) {
			AdvancedMovement.attack = false;
			impacted = false;
		}
		Impact ();
		Die ();
	}



	void Impact() {
		if(opponent != null && animation.IsPlaying(attack.name) && !impacted) {
			if((animation[attack.name].time) > impactTime && animation[attack.name].time < 0.9 * animation[attack.name].length ) {
				opponent.GetComponent<Mob>().GetHit(damage);
				impacted = true;
			}
		}
	}


	public void GetHit(int damage) {
		PlayerStats.curHealth = PlayerStats.curHealth - damage;
		if (PlayerStats.curHealth < 0) {
			PlayerStats.curHealth = 0;
		}
	}



	bool InRange() {
		if(Vector3.Distance(opponent.transform.position, transform.position) < range) {
			return true;
		}
		else {
			return false;
		}
	}

	public bool isDead() {
		if(PlayerStats.curHealth <= 0) {
			return true;
		}
		else {
			return false;
		}
	}

	void Die() {
		if(isDead() && !ended) {
			if(!started) {
				AdvancedMovement.die = true;
				animation.Play(dieClip.name);
				started = true;
			}

			if(started && !animation.IsPlaying(dieClip.name)) {
				//whatever you want to do
				Debug.Log ("You Have Died");

				ended = true;
				started = false;
			}
		}
	}

}
