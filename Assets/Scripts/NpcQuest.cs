using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class NpcQuest : MonoBehaviour {
	private AICharacterControl characterController;
	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowedDistance = 6;
	public GameObject TheNpc;
	public float FollowSpeed;
	public RaycastHit shot;
	private GameObject[] allWaypoints;
	private int currentWaypoint = 0;
	protected bool CanSeePlayer()
	{
		//function to determine whether the AI character can see the player

		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position; // get player position

		//we only want to look ahead so we check if the player in a 90 degree arc. (Vec3.angle returns an absolute value, so 45 degrees either way means <=45)
		if (Vector3.Angle(transform.forward, playerPosition - transform.position) <= 45f)
		{
			LayerMask layerMask = LayerMask.NameToLayer("Zombie");// a mask used for the raycast to ignore any zombies

			RaycastHit hit;// variable to store the hit so we can check it

			//We now check if a ray cast from us (the zombie) to the player hits anything (except zombies) also move it up a little to avoid the floor
			if (Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0f), playerPosition - transform.position, out hit, Mathf.Infinity, layerMask))
			{
				return (hit.collider.tag.Equals("Player"));//return whether or not the thing we hit is the player
			}
		}//or if any of these tests failed, i can't see them.
		return false;
	}

	void Start()
	{
		
		allWaypoints = GameObject.FindGameObjectsWithTag("WaypointNpc");
		//shuffle array to make unique wandering path
		System.Random rnd = new System.Random(System.DateTime.Now.Millisecond);
		allWaypoints = allWaypoints.OrderBy(x => rnd.Next()).ToArray();
	}
	void Update () {
		transform.LookAt (allWaypoints[currentWaypoint].transform); //look at wayponts and go at them
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out shot)) {
			//TargetDistance = shot.distance;
			//if (TargetDistance >= AllowedDistance) {
				FollowSpeed = 0.02f;
				characterController.SetTarget(allWaypoints[currentWaypoint].transform);
				//if i'm wandering...
				if ((Vector3.Distance(characterController.target.transform.position, transform.position) < 2.0f))
				{
					//...make me target the next one
					currentWaypoint++;
					//make sure that we don't fall off the end of the array but lop back round
					currentWaypoint %= allWaypoints.Length;
				}
				//can i see the player? if so, the chase is on!
				transform.Translate(Vector3.forward*5*Time.deltaTime);
				TheNpc.GetComponent<Animation> ().Play ("Rifle Run");
				transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, FollowSpeed);
		//	} else {
			//	FollowSpeed = 0;
			//
			//	TheNpc.GetComponent<Animation> ().Play ("Rifle Aiming Idle");
			}
		}
	}
//}
//public Transform target;
//public Transform myTransform;
//void Update () {

//	transform.LookAt(target);
//	transform.Translate(Vector3.forward*5*Time.deltaTime);

//}