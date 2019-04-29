using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAir : MonoBehaviour {

	public GameObject Curs;


	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Curs.GetComponent<Animator>().enabled = true;
			StartCoroutine(WaitingAnim());
		}
	}

	IEnumerator WaitingAnim ()
	{
		yield return new WaitForSeconds(0.10f);
		Curs.GetComponent<Animator>().enabled = false;
	}﻿
}
