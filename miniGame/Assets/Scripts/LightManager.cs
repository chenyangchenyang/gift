using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour 
{
	private string PrefabPath = "Prefabs/Light";

	private int LightCount= 10;

	private int LightSpace= 40;

	void Start () 
	{
		for(int x= 0; x< LightCount; ++x)
		{
			GameObject light= Resources.Load (PrefabPath) as GameObject;

			GameObject instanceLight= Instantiate (light);

			Vector3 pos = instanceLight.transform.position;
			pos.x = x * LightSpace;

			instanceLight.transform.position = pos;

			instanceLight.transform.parent = transform;
		}
	}
}
