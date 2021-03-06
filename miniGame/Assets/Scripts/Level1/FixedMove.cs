﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMove : MonoBehaviour
{
    public float time = 0.1f;

	void Start ()
    {
        Invoke("Move", 0.1f);
    }

    public void Move()
    {
        PlayerControl player = GameManager._instance.Player.GetComponent<PlayerControl>();

        if (player.move && player.speed > 0)
        {
            float v = time;

            if (player.lastDir.x< 0)
            {
                v *= -1.0f;
            }

            transform.position = new Vector3(transform.position.x + Time.deltaTime * v, transform.position.y, transform.position.z);
        }       

        Invoke("Move", 0.1f);
    }
}
