using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOpenControl : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GlobalTool.justOpened)
        {
            GlobalTool.Whiteout();
            GlobalTool.justOpened = false;
        }
    }
}


public partial class GlobalTool
{
    public static bool justOpened = true;
}