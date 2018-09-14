using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private Vector3 startPosition;
    private Vector3 offset;
    // Use this for initialization
    [HideInInspector]
    public GameObject lookGameObject;

	void Start () 
	{     
        lookGameObject = GameManager._instance.Player;

        startPosition = transform.position;

        //offset = transform.position - GameObject.FindGameObjectWithTag("OldMan").transform.position;
        offset = transform.position - lookGameObject.transform.position;

        if(!GlobalTool.Saves.ContainsKey(GameManager._instance.CameraDistancePlayer))
        {
            GlobalTool.SetString(GameManager._instance.CameraDistancePlayer, GameManager._instance.Vector3ToString(offset));
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
        float x= lookGameObject.transform.position.x;

        if (x <= GameManager._instance.GetLeftCameraBorder() ||
            x >= GameManager._instance.GetRightCameraBorder())
        {
            return;
        }

		if (transform.position.x < startPosition.x) 
		{
			transform.position = startPosition;
		}
        //Vector3 position = offset + GameObject.FindGameObjectWithTag("OldMan").transform.position;
        Vector3 position = offset + lookGameObject.transform.position;
        position.y = startPosition.y;
        transform.position = position;
    }
}
