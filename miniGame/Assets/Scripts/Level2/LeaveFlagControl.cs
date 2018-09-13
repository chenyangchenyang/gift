using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFlagControl : MonoBehaviour {

    private GameObject player;
    private GameObject parent;
    private bool left = false;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("S2Oldman");
        parent = GameObject.Find("Girl");
	}
	
	// Update is called once per frame
	void Update () {
		if (!left && Mathf.Abs(player.transform.position.x - transform.position.x) < 0.1)
        {
            parent.GetComponent<ParentControl>().Leave();
            left = true;
        }
	}
}
