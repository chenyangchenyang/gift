using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : WrappedBehaviour {

    private bool cheering = false;
    private Animation animation;
	// Use this for initialization
	void Start () {
        animation = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {
        if (!Scene2Global.cheering)
        {
            Scene2Global.Hide(gameObject);
            GameObject.Find("C" + gameObject.transform.parent.gameObject.name)
                .GetComponent<Scene22AlphaControl>().ChangeVisible(true);
            GameObject.Find("FishGirl").GetComponent<SpriteRenderer>().sprite =
                Resources.Load<Sprite>("img/第二关场景4/cheerGirl");
            ++Scene2Global.fishCount;
            Scene2Global.cheering = true;
            Invoke("SitGirl", 1.5f);
            if (Scene2Global.fishCount == 3)
            {
                Invoke("Leave", 3);
            }
        }
    }

    void Next()
    {
        Camera.main.GetComponent<CameraScene2>().Start2_4(1);
    }

    void SitGirl()
    {
        Scene2Global.cheering = false;
        GameObject.Find("FishGirl").GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("img/第二关场景4/sitGirl");
    }

    void Leave()
    {
        GameObject.Find("FishGirl").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GameObject.Find("FishOldMan").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GameObject.Find("Leaving").GetComponent<Scene22AlphaControl>().ChangeVisible(true);
        GameObject.Find("Junket").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GameObject.Find("CFish1").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GameObject.Find("CFish2").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GameObject.Find("CFish3").GetComponent<Scene22AlphaControl>().ChangeVisible(false);

        Invoke("ChangeBG4", 2);

        Invoke("Blackout", 2);
        Invoke("Next", 4);
        Invoke("Whiteout", 6);
    }

    void ChangeBG4()
    {
        GameManager._instance.BackGroundAudio.GetComponent<Level2BackGroundAudio>().ChangeHuiYi4();
    }
}
