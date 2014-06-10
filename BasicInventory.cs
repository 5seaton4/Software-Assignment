using UnityEngine;
using System.Collections;

public class BasicInventory : MonoBehaviour {

	public static int[] inventoryArray = {1, 2, 0, 0, 0};
	public GUIText inventoryText;

	public bool healthPotionCooldown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		inventoryText.text = "Health Potion " + "[" + inventoryArray[0] + "]" + "\n" + "Mana Potion" + "[" + inventoryArray[1] + "]";

		//inventoryArray [0]++;
		//inventoryArray [1] += 2; //comment out these 2 lines when makeing pickup items script

		if (Input.GetKeyDown ("f")){
			if (inventoryArray[0] > 0 && healthPotionCooldown == false)
			{
				healthPotionCooldown = true;
				StartCoroutine ("potionCooldown");
				HealthPotion();
			}
		}
	}

	void HealthPotion () {
		PlayerStats.curHealth += 100;
		inventoryArray [0] -= 1;
	}

	IEnumerator potionCooldown() {
		for (int x = 1; x < 2; x++) {
			yield return new WaitForSeconds(5);
			healthPotionCooldown = false;
		}
	}
}
