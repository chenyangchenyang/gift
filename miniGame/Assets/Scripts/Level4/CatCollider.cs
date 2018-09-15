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
            print("CatCollider rootGo");

            GetComponent<AudioSource>().Play();

            Invoke("Process", 0.5f);            
        }
    }

    private void Process()
    {
        GameManager._instance.ReStart();
    }
}
