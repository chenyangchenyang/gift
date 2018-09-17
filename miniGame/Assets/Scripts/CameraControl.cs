using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	private Vector3 startPosition;
    private Vector3 offset;
    // Use this for initialization
    [HideInInspector]
    public GameObject lookGameObject;
    [HideInInspector]
    public bool needMove = false;
    public Vector3 destination;
    public float speed = 10;

	void Start () 
	{     
        lookGameObject = GameManager._instance.Player;
        startPosition = transform.position;
        offset = transform.position - lookGameObject.transform.position;
    }
	
	// Update is called once per frame
	public void Update () 
	{
        if (needMove)
        {
            var dir = (destination - transform.position).normalized;
            var pos = transform.position + dir * speed * Time.deltaTime;
            transform.position = pos;
            if (Vector3.Distance(destination, transform.position) < 0.4)
            {
                transform.position = destination;
                needMove = false;
            }
        }
        else
        {
            if (lookGameObject == null) return;
            float x = lookGameObject.transform.position.x;

            if (x <= GameManager._instance.GetLeftCameraBorder() ||
                x >= GameManager._instance.GetRightCameraBorder())
            {
                if (GlobalTool.forceLookAtPlayer)
                {
                    GlobalTool.forceLookAtPlayer = false;
                    goto fixPosition;
                }
                return;
            }


fixPosition:
            if (transform.position.x < startPosition.x)
            {
                Vector3 tmp = transform.position;
                tmp.x = startPosition.x;
                transform.position = tmp;
            }
            //Vector3 position = offset + GameObject.FindGameObjectWithTag("OldMan").transform.position;
            var pos = transform.position;
            pos.x = lookGameObject.transform.position.x + offset.x;
            transform.position = pos;
        }
    }
}

public partial class GlobalTool
{
    public static bool forceLookAtPlayer = false;
}