using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RighthandControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseUpAsButton()
    {
        Scene2Global.Show(Scene2Global.rightHandXian);
        Scene2Global.Hide(Scene2Global.RightHand);
        Scene2Global.rightHandXianAlpha.ChangeVisible(true);
        Scene2Global.rightHandAlpha.ChangeVisible(false);
    }
}
