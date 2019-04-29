using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour1 : MonoBehaviour {
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			AudioSource gunsound  = GetComponent<AudioSource>();
			gunsound.Play();
			GetComponent<Animation>().Play("GunShot");
		}
	}
}

