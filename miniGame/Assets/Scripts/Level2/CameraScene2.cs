using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScene2 : MonoBehaviour {

    public Vector3 pos1 = new Vector3(-0.72f, -0.49f, -10f),
                    pos2 = new Vector3(27.45f, -17, -10),
                    pos4 = new Vector3(-0.7f, -34.58f, -10),
                    pos3 = new Vector3(-0.7f, -48, -10),
                    pos5 = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        if (GlobalTool.woodJump)
        {
            Start2_4(3);
        }
        else
        {
            Start2_1();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Start2_1()
    {
        transform.position = pos1;
    }

    public void Start2_2()
    {
        transform.position = pos2;
        Invoke("InvisibleBg1", 4);
    }

    public void Start2_4(int state)
    {
        transform.position = pos3;
        GameObject.Find("KnifeHand").GetComponent<KnifeControl>().woodState = state;
        GameObject.Find("WoodHand").GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("img/第二关场景3/mutou" + state);
        if (state != 1)
        {
            GameObject.Find("mudiao-background").transform.localScale = Vector3.zero;
        }
    }

    public void Start2_3()
    {
        transform.position = pos4;
    }

    public void Start2_5()
    {
        transform.position = pos5;
    }

    void InvisibleBg1()
    {
        Scene2Global.bg1Alpha.ChangeVisible(false);
        Invoke("HideBg1", 1);
    }

    void HideBg1()
    {
        Scene2Global.Hide(Scene2Global.bg1);
    }
}