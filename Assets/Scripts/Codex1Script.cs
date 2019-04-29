using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codex1Script : MonoBehaviour {

	public GameObject customImage;
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
		//	customImage.enabled = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player")) {
		//	customImage.enabled = false;
		}
}
}
