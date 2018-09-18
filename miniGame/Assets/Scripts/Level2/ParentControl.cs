using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentControl : MonoBehaviour {

    public float speed;
    private bool leaving;

	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<CameraControl>().lookGameObject = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        var dir = new Vector3(1, 0, 0);
		if (leaving)
        {
            transform.position = transform.position + speed * dir * Time.deltaTime;
        }

        if (Mathf.Abs(transform.position.x - GameObject.Find("Player").transform.position.x) >= 17)
        {
            GlobalTool.woodJump = true;
            GlobalTool.Blackout();

            Invoke("ChangeScene", 3);
            ChangeBGChangeHuiYi5Down();
        }
	}

    void ChangeScene()
    {
        GlobalTool.NonBg = false;

        SceneManager.LoadScene("Level2Recall");
    }

    public void Leave()
    {
        GetComponent<Animation>().Play("parentLeaving");
        leaving = true;
    }

    void ChangeBGChangeHuiYi5Down()
    {
        GameManager._instance.BackGroundAudio.GetComponent<Level2BackGroundAudio>().ChangeHuiYi5Down();
    }
}

public partial class GlobalTool
{
    static public bool NonBg= true;

    static public bool HasBG()
    {
        return NonBg;
    }
}
