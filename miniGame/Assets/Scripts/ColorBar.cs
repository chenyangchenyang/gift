using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class ColorBar : MonoBehaviour
{
    void Start()
    {
        lastPosition = gameObject.transform.position;
        targetPosition = gameObject.transform.position;

        var sg = gameObject.AddComponent<SpriteGlow>();
        sg.OutlineWidth = 0;

        Global.Bars[name] = gameObject;
    }

    void Update()
    {
        Global.Bars[name] = gameObject;
        if (!isOver)
        {
            Vector3 dist = targetPosition - lastPosition;
            transform.position += dist * 2 * Time.deltaTime;
            if (Vector3.Distance(targetPosition, transform.position) < 0.2f)
            {
                isOver = true;
                transform.position = targetPosition;
                lastPosition = targetPosition;
            }
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        foreach (var bar in Global.Bars.Values)
        {
            if (gameObject == bar) continue;
            if (Vector3.Distance(bar.transform.position, transform.position) < 1.0f)
            {
                // 交换目标位置
                bar.GetComponent<ColorBar>().targetPosition = lastPosition;
                bar.GetComponent<ColorBar>().isOver = false;
                targetPosition = bar.GetComponent<ColorBar>().lastPosition;
                isOver = false;

                lastPosition = transform.position;
                // 成功触发了拖拽交换
                GetComponent<SpriteGlow>().OutlineWidth = 0;
                Global.Selected = null;
                return;
            }
        }
        transform.position = lastPosition;
    }

    void OnMouseUpAsButton()
    {

        if (Global.Selected == null)
        {
            Global.Selected = gameObject;
            var spriteGlow = gameObject.GetComponent<SpriteGlow>();
            spriteGlow.OutlineWidth = 10;
        }
        else
        {
            targetPosition = Global.Selected.GetComponent<ColorBar>().lastPosition;
            Global.Selected.GetComponent<ColorBar>().targetPosition = lastPosition;
            isOver = false;
            Global.Selected.GetComponent<ColorBar>().isOver = false;
            var sg1 = gameObject.GetComponent<SpriteGlow>();
            var sg2 = Global.Selected.GetComponent<SpriteGlow>();
            sg1.OutlineWidth = 0;
            sg2.OutlineWidth = 0;
            Global.Selected = null;
        }
    }

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    Vector3 offset;
    Vector3 targetPosition;
    Vector3 lastPosition;
    bool isOver = false;
}

public class Global
{
    public static GameObject Selected = null;
    public static Dictionary<String, GameObject> Bars = new Dictionary<String, GameObject>();
}