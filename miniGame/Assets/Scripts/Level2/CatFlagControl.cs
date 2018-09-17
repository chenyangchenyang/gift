using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFlagControl : MonoBehaviour {
    public GameObject pictureToShow;
    public float threshold = 0.4f;
    public float showTime = 2f;
	// Use this for initialization
	void Start () {
		if (pictureToShow.GetComponent<Scene22AlphaControl>() == null)
        {
            var com = pictureToShow.AddComponent<Scene22AlphaControl>();
            com.SetVisible(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!triggered)
        {
            if (GameManager._instance.PuckBall != null)
            {
                if (Mathf.Abs(GameManager._instance.PuckBall.transform.position.x - transform.position.x) < threshold)
                {
                    triggered = true;
                    pictureToShow.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                    Invoke("Hide", 2);
                    return;
                }
            }
            if (Mathf.Abs(GameManager._instance.Player.transform.position.x - transform.position.x) < threshold)
            {
                triggered = true;
                pictureToShow.GetComponent<Scene22AlphaControl>().ChangeVisible(true);
                Invoke("Hide", 2);
                return;
            }
        }
	}

    void Hide()
    {
        pictureToShow.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
    }

    public bool triggered = false;
}
