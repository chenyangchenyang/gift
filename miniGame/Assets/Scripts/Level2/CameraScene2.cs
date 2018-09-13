using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScene2 : MonoBehaviour {

    public Vector3 pos1 = new Vector3(-0.72f, -0.49f, -10f),
                    pos2 = new Vector3(27.45f, -17, -10),
                    pos3 = new Vector3(-0.7f, -34.58f, -10);
	// Use this for initialization
	void Start () {
        Start2_2();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Start2_2()
    {
        transform.position = pos2;
        Invoke("InvisibleBg1", 2);
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
