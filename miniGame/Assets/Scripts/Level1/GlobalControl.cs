using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GlobalTool.scene1StartHandled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (!GlobalTool.scene1StartHandled)
        {
            if (!GlobalTool.needUi)
            {
                Camera.main.transform.position = new Vector3(-23.23f, -1.5f, -50);
                GlobalTool.scene1StartHandled = true;
                GameManager._instance.Player.GetComponent<PlayerControl>().StartMove();
                GameManager._instance.GetControl();
            }
        }
	}
}
