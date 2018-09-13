using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExtraControl : MonoBehaviour {

    public GameObject curtain;
    public Scene22AlphaControl curtainAlpha;

	// Use this for initialization
	void Start () {
        curtain = GameObject.Find("Curtain");
        curtainAlpha = curtain.GetComponent<Scene22AlphaControl>();
        curtainAlpha.SetVisible(false);
        var scale = curtain.transform.localScale;
        scale.x = scale.y = 100;
        curtain.transform.localScale = scale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var pos = Camera.main.transform.position;
        pos.z = 0;
        curtain.transform.position = pos;
    }

    public void Blackout()
    {
        curtainAlpha.ChangeVisible(true);
    }

    public void WhiteOut()
    {
        curtainAlpha.ChangeVisible(false);
    }
}
