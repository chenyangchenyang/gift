using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedThing : MonoBehaviour 
{

	public float StepDistance = 2;

	public float MaxRight= 35;
	public float MaxLeft= -4;

	public bool ToWardRight = true;

	void Update()
	{
		Vector3 move = new Vector3 (Time.deltaTime*StepDistance, 0, 0);

		if (!ToWardRight)
		{
			move*= -1;
		}

		transform.position += move;

		if(transform.position.x>= MaxRight)
		{
			ToWardRight = false;
		}
		else if(transform.position.x<= MaxLeft)
		{
			ToWardRight = true;
		}
	}
}
