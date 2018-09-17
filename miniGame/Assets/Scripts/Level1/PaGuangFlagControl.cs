using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaGuangFlagControl : MonoBehaviour {

    private GameObject light0, lightAlways, newbee;
	// Use this for initialization
	void Start () {
        if (GlobalTool.scene1Time > 0)
        {
            light0 = GameObject.Find("Light0");
            lightAlways = GameObject.Find("LightAlways");
            light0.transform.position = lightAlways.transform.position;
            lightAlways.SetActive(false);
            print("moving lightalways");
        }
        newbee = GameObject.Find("newbee");
        ++GlobalTool.scene1Time;
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

