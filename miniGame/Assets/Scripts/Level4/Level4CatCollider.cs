using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4CatCollider : MonoBehaviour
{
    public GameObject Shenti;
    public Sprite CatSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        GameObject rootGo = go.transform.root.gameObject;

        if (rootGo == GameManager._instance.Player)
        {
            Shenti.GetComponent<SpriteRenderer>().sprite = CatSprite;

            GetComponent<AudioSource>().Play();
        }
    }
}
