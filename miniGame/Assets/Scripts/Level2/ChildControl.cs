using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildControl : MonoBehaviour {

    public int state = 0;
    private ForegroundControl foreground;
	// Use this for initialization
	void Start () {
        state = 0;
        foreground = GameObject.FindGameObjectWithTag("Foreground2_1").GetComponent<ForegroundControl>();
    }
	
	// Update is called once per frame
	void Update () {
		switch (state)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = Resources.Load("img/第二关场景1/小孩背对", new Sprite().GetType()) as Sprite;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = Resources.Load("img/第二关场景1/小孩掉头", new Sprite().GetType()) as Sprite;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Resources.Load("img/第二关场景1/小孩伸手", new Sprite().GetType()) as Sprite;
                break;
            default:
                break;
        }
	}

    public void OnTouched()
    {
        if (state < 2)
        {
            state += 1;
            foreground.SwitchState();
        }
    }
}
