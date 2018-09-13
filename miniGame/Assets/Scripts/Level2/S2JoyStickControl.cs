using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2JoyStickControl : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("S2Oldman");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMove(Vector2 dir)
    {
        player.GetComponent<S2PlayerControl>().Walk();
    }

    public void OnMoveEnd()
    {
        player.GetComponent<S2PlayerControl>().StopWalking();
    }
}
