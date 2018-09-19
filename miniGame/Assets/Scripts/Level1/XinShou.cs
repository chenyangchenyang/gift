using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XinShou : MonoBehaviour
{
    public GameObject XinShouGO;

    private BoxCollider2D CurBoxCollider2D;

    private void Start()
    {
        CurBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(" GlobalTool.TotalDeathCount:" + GlobalTool.TotalDeathCount);

        if(0 != GlobalTool.TotalDeathCount )
        {
            return;
        }

        GameObject go = collision.gameObject;

        GameObject rootGo = go.transform.root.gameObject;

        if (rootGo == GameManager._instance.Player)
        {
            XinShouGO.SetActive(true);

            Destroy(CurBoxCollider2D);
        }
    }

    public void OnReleaseControl()
    {
        PlayerControl pcl = GameManager._instance.Player.GetComponent<PlayerControl>();

        pcl.PauseMove();

        GameManager._instance.ReleaseControl();
    }

    public void OnGetControl()
    {
        PlayerControl pcl = GameManager._instance.Player.GetComponent<PlayerControl>();

        pcl.StartMove();

        GameManager._instance.GetControl();
    }
}
