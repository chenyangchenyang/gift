using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2PlayerControl : MonoBehaviour {
    
    public float speed;
    private bool walking = false;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (walking)
        {
            rb.MovePosition(rb.position + new Vector2(1, 0) * speed * Time.deltaTime);
        }
	}

    public void Walk()
    {
        walking = true;
        GetComponent<Animation>().Play("S2OldmanWalk");
    }

    public void StopWalking()
    {
        walking = false;
    }
}
