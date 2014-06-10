using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHealth = 100;

	public GUIText displayDamage;
	public GUIText enemyHealthText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemyHealthText.text = "Enemy HP " + enemyHealth;
		if (this.enemyHealth <= 0) {
			enemyHealth = 0;
			PlayerStats.curExp += 10;
			Destroy(this.gameObject);
		}

	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "AttackArea") {

			if(Input.GetKeyDown("1")) {
				int randomDamage = Random.Range (PlayerStats.minAttack, PlayerStats.maxAttack) * PlayerStats.attackPower;
				this.enemyHealth -= randomDamage;
				displayDamage.text = "Damage " + randomDamage;
			}
		}
	}
}
