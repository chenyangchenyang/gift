using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go= collision.gameObject;

        GameObject rootGo = go.transform.root.gameObject;

        if(rootGo== GameManager._instance.Player)
        {
            GameManager._instance.ReStart();
        }
    }
}
