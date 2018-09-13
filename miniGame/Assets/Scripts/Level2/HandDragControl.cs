using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDragControl : MonoBehaviour {

    private Vector3 offset;
    private Vector3 originPos;
    private Scene2GlobalControl global;

	// Use this for initialization
	void Start () {
        originPos = transform.position;
        global = GameObject.Find("GlobalHandler").GetComponent<Scene2GlobalControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        transform.position = offset + Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        if (Vector3.Distance(Scene2Global.leftHandPi.transform.position, Scene2Global.rightHandXian.transform.position) < 1.5f)
        {
            Scene2Global.leftHandPiAlpha.ChangeVisible(false);
            Scene2Global.rightHandXianAlpha.ChangeVisible(false);
            Invoke("AddDumpling", 1);
        }
        else
        {
            transform.position = originPos;
        }
    }

    void AddDumpling()
    {
        global.ShowTwoHands();
    }

    
}
