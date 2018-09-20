using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    public void UnActive()
    {
        gameObject.SetActive(false);

        GameManager._instance.ReStart();
    }
}
