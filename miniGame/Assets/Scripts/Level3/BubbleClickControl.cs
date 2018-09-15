using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleClickControl : WrappedBehaviour {
    private bool handled = false;
    private GameObject player;
    private GameObject[] bg = new GameObject[3];
    private GameObject letter, pen, content, yeye;
    private GameObject joystick, smallBubble, bigBubble;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        bg[0] = GameObject.Find("bg");
        bg[1] = GameObject.Find("paper");
        bg[2] = GameObject.Find("title");
        letter = GameObject.Find("letter");
        pen = GameObject.Find("pen");
        content = GameObject.Find("content");
        joystick = GameObject.Find("New Joystick");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("UI"), LayerMask.NameToLayer("playerBody"));
        smallBubble = GameObject.Find("BigBubble");
        bigBubble = GameObject.Find("smallBubble");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        Invoke("Blackout", 0);
        Invoke("ShowLetter", 2);
    }

    void ShowLetter()
    {
        letter.transform.position = Camera.main.transform.position + new Vector3(0, 0, 10);
        for (int i = 0; i < 3; ++i)
        {
            bg[i].GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        }
        pen.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        pen.GetComponent<DragControl>().originPos = pen.transform.position;
    }
}
