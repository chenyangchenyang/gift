using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    public Camera cam;
    private float timeHit = 0f;         //用于点击的时间间隔,每次点击时间间隔应大于0.2秒  
    private OldmanControl oldman;
    private ChildControl child;
    // Use this for initialization
    void Start () {
        oldman = GameObject.Find("Oldman").GetComponent<OldmanControl>();
        child = GameObject.Find("Children").GetComponent<ChildControl>();
	}
	
	// Update is called once per frame
	void Update () {
        timeHit += Time.deltaTime;
        if (timeHit > 0.2f)
        {
            if (Input.GetMouseButton(0))
            {
                timeHit = 0f;
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    hit.collider.gameObject.SendMessage("OnTouched", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

        // 检查老人和小孩的状态
        if (oldman.state == 1 && child.state == 2)
        {

        }
    }
}
