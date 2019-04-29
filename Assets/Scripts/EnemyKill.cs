using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour {

	public int EnemyHealth = 10;

	void deductPoints (int damageAmount) 
	{
		EnemyHealth -= damageAmount;
	}

	void Update () {
		if (EnemyHealth <= 0) {
			Destroy(gameObject);
		}
	}
}
