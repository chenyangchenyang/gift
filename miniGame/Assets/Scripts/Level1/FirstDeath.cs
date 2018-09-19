using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDeath : MonoBehaviour
{
    public GameObject Img;
	public Vector3 Offset;

    public void ActiveImg()
    {
        Img.transform.position = GameManager._instance.Player.transform.position + Offset;

        Img.SetActive(true);
    }
}
