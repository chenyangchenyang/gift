﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControl : MonoBehaviour {

    [HideInInspector]
    public GameObject player;

    public bool ToRight = true;
    private GameObject body;
	// Use this for initialization
	void Start ()
    {
        GetControlPlayer();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMove(Vector2 dir)
    {
        if(null == player)
        {
            return;
        }

        if ((dir.x > 0) != ToRight)
        {
            var scale = body.transform.localScale;
            scale.x *= -1;
            body.transform.localScale = scale;
        }
        ToRight = (dir.x > 0);
        player.GetComponent<PlayerControl>().dir = dir;
        player.GetComponent<PlayerControl>().lastDir = dir;
        player.GetComponent<PlayerControl>().move = true;
        player.GetComponent<Animator>().SetBool("Walking", true);
    }

    public void OnMoveEnd()
    {
        if(null ==player)
        {
            return;
        }

        player.GetComponent<PlayerControl>().dir = Vector2.zero;
        player.GetComponent<PlayerControl>().move = false;
        player.GetComponent<Animator>().SetBool("Walking", false);
    }

    public void ReleaseControlPlayer()
    {
        player = null;
        body = null;
    }

    public void GetControlPlayer()
    {
        player = GameManager._instance.Player;
        body = player.transform.GetChild(0).gameObject;
    }
}
