using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedThing : MonoBehaviour 
{

	public float StepDistance = 2;

    public float Length = 5;

	private float MaxRight;
    private float MaxLeft;

	public bool ToWardRight = true;

    private void Start()
    {
        MaxRight = transform.position.x+ Length;
        MaxLeft  = transform.position.x- Length;
    }

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
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
			ToWardRight = false;
		}
		else if(transform.position.x<= MaxLeft)
		{
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            ToWardRight = true;
		}
	}
}
