using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    public void UnActive()
    {
        gameObject.transform.root.gameObject.SetActive(false);
    }
}
