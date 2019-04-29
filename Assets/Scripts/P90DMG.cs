using UnityEngine;
using System.Collections;

public class P90DMG : MonoBehaviour
{
	public int damageAmount = 2;
	public float targetDistance;
	public float allowedRange = 15f;

	// Update is called once per frame
	void Update ()
	{
		RaycastHit Shot;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out Shot))
		{
			targetDistance = Shot.distance;
			if (targetDistance < allowedRange)
			{
				Shot.transform.SendMessage("deductPoints", damageAmount , SendMessageOptions.DontRequireReceiver );
			}

		}
	}
}
