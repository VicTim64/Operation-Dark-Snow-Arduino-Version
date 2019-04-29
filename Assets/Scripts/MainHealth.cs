using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHealth : MonoBehaviour {
//	public  death;
	public Image currentHealthbar;
	public Text ratioText;

	private float hitpoint = 150;
	private float maxHitpoint = 150;

	private void Start()
	{
		UpdateHealthbar ();

	}
	private void UpdateHealthbar()
	{
		float ratio = hitpoint / maxHitpoint;
		currentHealthbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio * 100).ToString ("0") + "%";
	}
	public  void TakeDamage(float damage)
	{
		hitpoint -= damage;
		if (hitpoint < 0) {
			hitpoint = 0;
			Ard02.sendDeathSignal();
			Destroy (gameObject);
			Application.LoadLevel ("Plane Crash");
			 
	//		death.SetActive (true);
		}
		UpdateHealthbar();
	}
	private void HealDamage (float heal)
	{
		hitpoint += heal;
		if (hitpoint > maxHitpoint) {
			hitpoint = maxHitpoint;
			//		death.SetActive (true);
			UpdateHealthbar ();
		}
	}
	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.tag == "Zombie" || _collision.gameObject.tag == "Zombie2" || _collision.gameObject.tag == "Zombie3") {
			TakeDamage (20);
		}
}
}
