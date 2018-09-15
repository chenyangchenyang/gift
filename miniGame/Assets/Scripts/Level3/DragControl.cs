using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : WrappedBehaviour {

    public Vector3 originPos;
    private Vector3 offset;
    private float dist = 0;
    private Vector3 lastPos;
    private GameObject player;
    private GameObject[] bg = new GameObject[3];
    private GameObject letter, pen, content, yeye;
    private GameObject joystick;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        bg[0] = GameObject.Find("bg");
        bg[1] = GameObject.Find("paper");
        bg[2] = GameObject.Find("title");
        letter = GameObject.Find("letter");
        pen = GameObject.Find("pen");
        yeye = GameObject.Find("yeye");
        content = GameObject.Find("content");
        joystick = GameObject.Find("New Joystick");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastPos = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        dist += Vector3.Distance(transform.position, lastPos);
        if (dist > 8)
        {
            content.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
            yeye.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
            Invoke("FinishLetter", 4);
            Invoke("Whiteout", 5);
        }
        lastPos = transform.position;
    }

    private void OnMouseUp()
    {
        transform.position = originPos;
    }

    private void FinishLetter()
    {
        for (int i = 0; i < 3; ++i)
        {
            bg[i].GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        }
        pen.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        yeye.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        content.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        Invoke("RemoveLetter", 1.5f);
    }

    private void RemoveLetter()
    {
        letter.transform.position = new Vector3(1000, 10000, 0);
        joystick.SetActive(true);
        GameObject.Find("GlobalHandler").GetComponent<JoyStickControl>().OnMoveEnd();
    }
}
