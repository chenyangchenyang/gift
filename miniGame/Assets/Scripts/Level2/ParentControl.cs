using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentControl : MonoBehaviour {

    public float speed;
    private bool leaving;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var dir = new Vector3(1, 0, 0);
		if (leaving)
        {
            transform.position = transform.position + speed * dir * Time.deltaTime;
        }

        if (Mathf.Abs(transform.position.x - GameObject.Find("S2Oldman").transform.position.x) >= 21)
        {
            GlobalTool.woodJump = true;
            GlobalTool.Blackout();
            Invoke("ChangeScene", 3);
        }
	}

    void ChangeScene()
    {
        SceneManager.LoadScene("第二关");
    }

    public void Leave()
    {
        GetComponent<Animation>().Play("parentLeaving");
        leaving = true;
    }
}
