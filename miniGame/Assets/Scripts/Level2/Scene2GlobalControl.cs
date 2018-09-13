using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2GlobalControl : MonoBehaviour {

    int dumplings = 4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowTwoHands()
    {
        ++dumplings;
        Scene2Global.Hide(Scene2Global.leftHandPi);
        Scene2Global.Hide(Scene2Global.rightHandXian);
        Scene2Global.twoHandsAlpha.ChangeVisible(true);
        if (dumplings == 5)
        {
            Invoke("Show5Dumpling", 1);
        }
        else
        {
            Invoke("Show6Dumpling", 1);
        }
    }

    void Show5Dumpling()
    {
        Scene2Global.dumplings5Alpha.ChangeVisible(true);
        Scene2Global.twoHandsAlpha.ChangeVisible(false);
        Invoke("Reset2Hands", 1.3f);
    }

    void Show6Dumpling()
    {
        Scene2Global.dumplings6Alpha.ChangeVisible(true);
        Scene2Global.twoHandsAlpha.ChangeVisible(false);
        // 结束场景
        Invoke("ShowBg2", 2);
    }

    void ShowBg2()
    {
        Scene2Global.Show(Scene2Global.bg2);
        Scene2Global.bg2Alpha.ChangeVisible(true);
    }

    void Reset2Hands()
    {
        Scene2Global.leftHand.transform.position = Scene2Global.leftHandPos;
        Scene2Global.RightHand.transform.position = Scene2Global.rightHandPos;
        Scene2Global.rightHandXian.transform.position = Scene2Global.rightHandXianPos;
        Scene2Global.leftHandPi.transform.position = Scene2Global.leftHandPiPos;
        Scene2Global.twoHandsAlpha.ChangeVisible(false);
        Scene2Global.leftHandAlpha.ChangeVisible(true);
        Scene2Global.rightHandAlpha.ChangeVisible(true);
        Scene2Global.Show(Scene2Global.leftHand);
        Scene2Global.Show(Scene2Global.RightHand);
    }
}
