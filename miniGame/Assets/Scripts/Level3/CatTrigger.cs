using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTrigger : MonoBehaviour {

    public GameObject CatGO;
    public Sprite CatSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        GameObject rootGo = go.transform.root.gameObject;

        if (rootGo == GameManager._instance.Player)
        {
            CatGO.GetComponent<SpriteRenderer>().sprite = CatSprite;
        }
    }
}
