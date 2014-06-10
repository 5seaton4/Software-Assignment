using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public static float curHealth = 300;
	public static float maxHealth = 300;
	public static float curMana = 300;
	public static float maxMana = 300;
	public static int maxExp = 100;
	public static int curExp = 90;
	public static int level = 1;

	public static int attackPower = 2;
	public static int minAttack = 10;
	public static int maxAttack = 30;

	public Texture2D HealthBarTexture;
	public Texture2D ManaBarTexture;

	public float healthBarLength;
	public float percentOfHealth;

	public float manaBarLength;
	public float percentOfMana;


	public GUIText statsText;

	// Use this for initialization
	void Start () {
		StartCoroutine ("HealthRegen", 0.5);	
	}
	
	// Update is called once per frame
	void Update () {

		percentOfHealth = curHealth / maxHealth;
		healthBarLength = percentOfHealth * 100;

		percentOfMana = curMana / maxMana;
		manaBarLength = percentOfMana * 100;

		if (curExp < 0) {
			curExp = 0;
		}

		if (curExp >= maxExp) {
			level++;
			curExp = 0;
		}


		statsText.text = "Health: " + curHealth + " / " + maxHealth + "\n" + "Mana: " + curMana + " / " + maxMana + "\n"  + "Exp: "+ curExp + " / " + maxExp + "\n" + "Level: " + level;

		if(curHealth < 0) {
			curHealth = 0;
		}
		if(curHealth > 300) {
			curHealth = 300;
		}

		if (Input.GetKeyDown ("r")) {
			curHealth -= 10;
		}

		if (Input.GetKeyDown ("m")) {
			curMana -= 10;
		}

		if (Input.GetKeyDown ("o")) {
			curExp += 10;
		}
	}

	IEnumerator HealthRegen(float timeWait) {
		for (int i = 1; i > 0; i++) {
			if(curHealth <maxHealth) {
				curHealth++;
			}

			yield return new WaitForSeconds(0.5f);

			
		}
	}

	void OnGUI() {

		if(curHealth > 0) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 100, 10, healthBarLength, 10), HealthBarTexture);
		}

		if (curMana > 0) {
			GUI.DrawTexture(new Rect ((Screen.width / 2) - 100, 20, manaBarLength, 10), ManaBarTexture);
		}
	}

}
