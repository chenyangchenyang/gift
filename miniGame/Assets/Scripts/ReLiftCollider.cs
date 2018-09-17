using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLiftCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go= collision.gameObject;

        GameObject rootGo = go.transform.root.gameObject;

        if(rootGo== GameManager._instance.Player || rootGo== GameManager._instance.PuckBall)
        {
            GlobalTool.SetString(GameManager._instance.PlayerPosition, GameManager._instance.Vector3ToString(rootGo.transform.position));
            GlobalTool.SetString(GameManager._instance.CameraPosition, GameManager._instance.Vector3ToString(
                GameManager._instance.CaremaObject.transform.position));
        }
    }
}
