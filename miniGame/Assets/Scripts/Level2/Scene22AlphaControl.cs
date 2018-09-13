using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene22AlphaControl : MonoBehaviour {

    float speed = 2.5f;
    public bool visible = true;
    private SpriteRenderer renderer;
    

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        SetVisible(visible);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Color color = renderer.color;
        if (visible && color.a < 1)
        {
            color.a += speed * Time.deltaTime;
        }
        else if (!visible && color.a > 0)
        {
            color.a -= speed * Time.deltaTime;
        }
        renderer.color = color;
	}

    // 渐变
    public void ChangeVisible(bool visible)
    {
        this.visible = visible;
    }

    // 突变
    public void SetVisible(bool visible)
    {
        this.visible = visible;
        Color color = renderer.color;
        color.a = visible ? 1 : 0;
        renderer.color = color;
    }
}
