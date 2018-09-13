using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundControl : MonoBehaviour {
    public int state = 0;

	// Use this for initialization
	void Start () {
        state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = Resources.Load("img/第二关场景1/前景2", new Sprite().GetType()) as Sprite;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = Resources.Load("img/第二关场景1/前景1", new Sprite().GetType()) as Sprite;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Resources.Load("img/第二关场景1/前景0", new Sprite().GetType()) as Sprite;
                break;
            default:
                break;
        }
	}

    public void SwitchState()
    {
        if (state < 2)
        {
            state += 1;
        }
    }
}
