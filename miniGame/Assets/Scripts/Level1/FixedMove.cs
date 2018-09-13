using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMove : MonoBehaviour
{
    public float time = 0.1f;

	void Start ()
    {
        Invoke("Move", 0.1f);
    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime* time, transform.position.y, transform.position.z);

        Invoke("Move", 0.1f);
    }
}
