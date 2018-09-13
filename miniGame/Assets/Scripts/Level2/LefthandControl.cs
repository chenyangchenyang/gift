using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LefthandControl : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Scene2Global.Init();
        Scene2Global.Hide(Scene2Global.leftHandPi);
        Scene2Global.Hide(Scene2Global.rightHandXian);
        Scene2Global.Hide(Scene2Global.bg2);
    }

    void OnMouseUpAsButton()
    {
        Scene2Global.Show(Scene2Global.leftHandPi);
        Scene2Global.Hide(Scene2Global.leftHand);
        Scene2Global.leftHandPiAlpha.ChangeVisible(true);
        Scene2Global.leftHandAlpha.ChangeVisible(false);
    }
}

public class Scene2Global
{
    public static Scene22AlphaControl leftHandAlpha, rightHandAlpha, 
        leftHandPiAlpha, rightHandXianAlpha, dumplings5Alpha, dumplings6Alpha,
        twoHandsAlpha, bg1Alpha, bg2Alpha;
    public static GameObject leftHand, RightHand, leftHandPi, rightHandXian, twoHands, bg1, bg2;
    public static Vector3 leftHandPos, rightHandPos, leftHandPiPos, rightHandXianPos;

    public static void Init()
    {
        leftHand = GameObject.Find("LeftHand");
        RightHand = GameObject.Find("RightHand");
        leftHandPi = GameObject.Find("LeftHandPi");
        rightHandXian = GameObject.Find("RightHandXian");
        twoHands = GameObject.Find("TwoHand");
        bg1 = GameObject.Find("Background2_2");
        bg2 = GameObject.Find("Background2_4");

        leftHandAlpha = leftHand.GetComponent<Scene22AlphaControl>();
        rightHandAlpha = RightHand.GetComponent<Scene22AlphaControl>();
        leftHandPiAlpha = leftHandPi.GetComponent<Scene22AlphaControl>();
        rightHandXianAlpha = rightHandXian.GetComponent<Scene22AlphaControl>();
        dumplings5Alpha = GameObject.Find("Dumplings5").GetComponent<Scene22AlphaControl>();
        dumplings6Alpha = GameObject.Find("Dumplings6").GetComponent<Scene22AlphaControl>();

        bg1Alpha = bg1.GetComponent<Scene22AlphaControl>();
        bg2Alpha = bg2.GetComponent<Scene22AlphaControl>();
        twoHandsAlpha = twoHands.GetComponent<Scene22AlphaControl>();
        leftHandPos = leftHand.transform.position;
        rightHandPos = RightHand.transform.position;
        leftHandPiPos = leftHandPi.transform.position;
        rightHandXianPos = rightHandXian.transform.position;
    }

    public static void Hide(GameObject o)
    {
        o.transform.localScale = Vector3.zero;
    }

    public static void Show(GameObject o)
    {
        o.transform.localScale = Vector3.one;
    }
}
