﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheatreBubbleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        Camera.main.GetComponent<TheaterCameraControl>().CloseCurtain();
    }
}
