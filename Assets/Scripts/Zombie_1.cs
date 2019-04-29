using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_1 : MonoBehaviour {
	public Transform player;
	static Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindWithTag ("Player").GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (player.position, this.transform.position) < 27) 
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
	}
}
}
