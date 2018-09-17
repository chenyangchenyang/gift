using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaGuangFlagControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GlobalTool.firstDeath && !GlobalTool.hasShownPaGuang)
        {
            var PaGuangAnim = GameObject.Find("怕光").GetComponent<Animation>().Play("paGuang");
            GlobalTool.hasShownPaGuang = true;
        }
	}
}
