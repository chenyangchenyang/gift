using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToActiveGameObjects : MonoBehaviour
{
    public GameObject ActiveObject;
    public GameObject[] DestoryObjects;

    public void OnMouseDown()
    {
        if(null != ActiveObject)
        {
            ActiveObject.SetActive(true);
        }
       
        if(null != DestoryObjects)
        {
            for (int i = 0; i < DestoryObjects.Length; ++i)
            {
                DestoryObjects[i].SetActive(false);
            }
        }

        if("ChildPaint" == gameObject.name)
        {
            GameManager._instance.Player.GetComponent<PlayerControl>().StartMove();
        }
    }
}
