using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour {

    private int state = 1;
    private float timePast = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timePast += Time.deltaTime;
	}

    private void OnMouseUpAsButton()
    {
        if (timePast > 3)
        {

        }
    }
}
