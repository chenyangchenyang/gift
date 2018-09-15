using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoutongControl : WrappedBehaviour {

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
        if (!handled)
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 2)
            {
                handled = true;
                smallBubble.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                bigBubble.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                GameManager._instance.Player.GetComponent<PlayerControl>().PauseMove();
                GameManager._instance.ReleaseControl();
            }
        }
	}


}
