using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStarControl : MonoBehaviour 
{
	public float LightOnTime= 3.0f;
	public float LightDownTime= 3.0f;

    private float UpDistance = 10000.0f;

    private Vector3 LightStartPosition;
    private Vector3 LightNewPosition;

    void Start () 
	{
        LightStartPosition = transform.position;

        LightNewPosition = LightStartPosition;
        LightNewPosition.y = UpDistance;

        Invoke ("DownLight",LightOnTime);
	}

	void DownLight()
	{
        transform.position = LightNewPosition;

		Invoke ("OnLight",LightDownTime);
	}

	void OnLight()
	{
        transform.position = LightStartPosition;

        Invoke ("DownLight",LightOnTime);
	}
}
