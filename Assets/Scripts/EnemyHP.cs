using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHP : MonoBehaviour {
	[SerializeField]
	//private int health = 100;
	private int maxHealth = 100;
	private int currentHealth;
	public event Action<float> OnHealthPctChanged = delegate {};

	private void OnEnable()
	{
		currentHealth = maxHealth;
	}
	public void ModifyHealth(int amount)
	{
		currentHealth += amount;
		float currentHealthPct = (float)currentHealth / (float)maxHealth;
		OnHealthPctChanged (currentHealthPct);
	}
	//private void Update()
//	{
		



	void ApplyDamage (int TheDamage)
	{
		ModifyHealth (-25);
		//health -=TheDamage;
		if (currentHealth <=0)
		{
			Destroy(gameObject);
		}
}
}