using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewbeeControl : MonoBehaviour {

    public bool show = false;

	
	// Update is called once per frame
	void LateUpdate () {
		if (show)
        {
            transform.position = Camera.main.transform.position + new Vector3(0, -2, 10);
        }
	}
}
