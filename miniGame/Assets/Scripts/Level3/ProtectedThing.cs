using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedThing : MonoBehaviour 
{
	public float FootStepV     = 2.0f;

    public float VanishPostion = 2.0f;

    private void Start()
    {
      
    }

    void Update()
	{
		Vector3 move = new Vector3 (Time.deltaTime* FootStepV, 0, 0);
		
		transform.position += move;

		if(transform.position.x>= VanishPostion)
		{
            Destroy(gameObject);
		}
	}
}
