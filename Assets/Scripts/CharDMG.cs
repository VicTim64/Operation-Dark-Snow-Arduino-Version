using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharDMG : MonoBehaviour {
	public float moveSpeed;

	public Animator myAnimation;

	public bool hurt;

	public int health;
	public bool isDead;

	void Death()
	{
		moveSpeed = 0;
		myAnimation.SetFloat("Speed", 0);
		myAnimation.SetBool("Death", true);
		isDead = true;
	}

	public IEnumerator Hurt(int damage)//in paranteza int damage
	{
		
		if (health>0)
		{
			print("Hit");
			health -= damage;
			hurt = true;
		}
		yield return new WaitForSeconds(1);
		hurt = false;
	}
	private void OnTriggerEnter(Collider collision)//OnTriggerEnter(.....)
	{
		if (collision.tag == "nodecal")//collision.tag == "Zombie"
		{
			if (!hurt)
			{
				StartCoroutine(Hurt(30));

			}

		}
	}
}
