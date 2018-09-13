using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappedBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Blackout()
    {
        GlobalTool.Blackout();
    }

    void Whiteout()
    {
        GlobalTool.Whiteout();
    }
}
