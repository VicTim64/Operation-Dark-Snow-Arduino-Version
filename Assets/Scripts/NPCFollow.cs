using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour {

	public GameObject ThePlayer;
	public float TargetDistance;
	//public float AllowedDistance = 18;
	public GameObject TheNpc;
	public float FollowSpeed;
	public RaycastHit shot;
	//private bool npc_wait = false;
	//Random randomDistance = new Random();
	int AllowedDistance =12;// Random.Range(6,18);
	void Update () {
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out shot)) {
			TargetDistance = shot.distance;
			if (TargetDistance >= AllowedDistance) {
				FollowSpeed = 0.02f;
				transform.Translate (Vector3.forward * 2 * Time.deltaTime);
				TheNpc.GetComponent<Animation> ().Play ("Rifle Run");
				transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, FollowSpeed);
			} else {
				FollowSpeed = 0;
				//	npc_wait = true;
				TheNpc.GetComponent<Animation> ().Play ("Rifle Aiming Idle");
			}

		//	if (npc_wait == true ) {
			//	npc_wait = false;
			//}
		}
	}


}
//public Transform target;
//public Transform myTransform;
//void Update () {

//	transform.LookAt(target);
//	transform.Translate(Vector3.forward*5*Time.deltaTime);

//}