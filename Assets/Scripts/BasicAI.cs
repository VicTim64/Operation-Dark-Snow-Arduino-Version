using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour
{   
	private Transform target;
	public Transform myTransform;
	private GameObject FPSController;
	float speed;
	bool playerInRange;
	Animator m_Animator;
	//bool m_Walk;

	private void Start()
	{
		FPSController = GameObject.FindGameObjectWithTag("Player");
		target = FPSController.GetComponent<Transform>();
		m_Animator = gameObject.GetComponent<Animator>();
		//m_Walk = false;
	}
	void Update()
	{

		Vector3 direction = FPSController.transform.position - transform.position;
		direction.y = 0;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		transform.Translate(0, 0, speed);
		if (playerInRange) { speed = 0.0f; }
		else { speed = 0.02f; }

	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject == FPSController)
			playerInRange = true;


	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == FPSController)
			playerInRange = false;
	}


}