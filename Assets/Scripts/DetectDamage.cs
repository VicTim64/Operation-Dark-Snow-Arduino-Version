using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectDamage : MonoBehaviour {
	public Slider healthbar;
	void OnTriggerEnter(Collider other)
	{
		healthbar.value -= 20;
		Debug.Log ("Damage");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
