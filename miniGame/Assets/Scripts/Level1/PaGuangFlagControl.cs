using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaGuangFlagControl : MonoBehaviour {

    private GameObject light0, lightAlways, newbee;
	// Use this for initialization
	void Start () {
        light0 = GameObject.Find("Light0");
        lightAlways = GameObject.Find("LightAlways");
        if (GlobalTool.scene1Time > 0)
        {
            lightAlways.transform.localScale = Vector3.zero;
        } else
        {
            light0.transform.localScale = Vector3.zero;
        }
        newbee = GameObject.Find("newbee");
        ++GlobalTool.scene1Time;
        GlobalTool.forceLookAtPlayer = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalTool.scene1Time > 1 && !GlobalTool.hasShownPaGuang)
        {
            if (Mathf.Abs(GameManager._instance.Player.transform.position.x - transform.position.x) < 0.5)
            {
                var PaGuangAnim = GameObject.Find("怕光").GetComponent<Animation>().Play("paGuang");
                GlobalTool.hasShownPaGuang = true;
            }
        }
	}
}

