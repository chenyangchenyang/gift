using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudiaoOpenControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUpAsButton()
    {
        GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        transform.GetChild(0).gameObject.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GlobalTool.needCheckKnifeIdle = true;
        GlobalTool.idleTime = 0;
        Invoke("ShowS1", 2);
    }

    void ShowS1()
    {
        GameObject.Find("sentence1").GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        Invoke("HideS1", 2);
    }

    void HideS1()
    {
        GameObject.Find("sentence1").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        Invoke("RemoveS1", 1);
    }

    void RemoveS1()
    {
        GlobalTool.Hide(GameObject.Find("sentence1"));
    }
}
