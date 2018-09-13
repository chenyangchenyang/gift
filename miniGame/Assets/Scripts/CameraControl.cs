using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private Vector3 startPosition;
    private Vector3 offset;
    // Use this for initialization
    public GameObject lookGameObject;

	void Start () 
	{
		startPosition = transform.position;

        //offset = transform.position - GameObject.FindGameObjectWithTag("OldMan").transform.position;
        offset = transform.position - lookGameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () 
	{
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
