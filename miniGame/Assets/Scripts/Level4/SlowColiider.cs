using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowColiider : MonoBehaviour
{
    public float SpeedPerMS;
    public float FinialV;

    private PlayerControl Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        GameObject rootGo = go.transform.root.gameObject;

        print("SlowColiider:OnTriggerEnter2D:"+ rootGo.name);

        if (rootGo == GameManager._instance.Player)
        {
            Player = GameManager._instance.Player.GetComponent<PlayerControl>();

            StartCoroutine(Slow());
        }           
    }

    private IEnumerator Slow()
    {
        print("Slow.speed:" + Player.speed);

        while (Player.speed > FinialV)
        {
            Player.speed -= SpeedPerMS;

            print("Player.speed:"+ Player.speed);

            yield return new WaitForSeconds(0.001f);
        }
    }
}
