using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuest1 : MonoBehaviour {

	private GameObject triggerinNpc;
	private bool triggering;
	private GameObject trigerincod1;
	private bool trigercod1;
	public GameObject text_f;
	public GameObject codex1;
	// Update is called once per frame
	void Update () {

		if (triggering || trigercod1 ) {
			text_f.SetActive (true);
			if (Input.GetKeyDown (KeyCode.F) && trigercod1) {
				codex1.SetActive(true);
			}
		} else {
			text_f.SetActive (false);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "NPC1") {
			triggering = true;
			triggerinNpc = other.gameObject;
		}
		if (other.tag == "Codex1") {
			trigercod1 = true;
			trigerincod1 = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "NPC1") {
			triggering = false;
			triggerinNpc = null;
		}
		if (other.tag == "Codex1") {
			trigercod1 = false;
			trigerincod1 = null;
			codex1.SetActive (false);
		}
	}
}
