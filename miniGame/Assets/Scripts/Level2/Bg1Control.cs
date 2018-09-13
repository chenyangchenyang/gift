using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg1Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTouched()
    {
        Scene2Global.bg1Alpha.ChangeVisible(true);
    }
}
