using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupLightControl : MonoBehaviour 
{
	public GameObject[] Lights;

	private int[] ControlLightIndexs;

	private DynamicLight2D.DynamicLight[] DynamicLights;

	private Vector3 UpDistance= new Vector3(0,100, 0);

	private void Awake()
	{
		InitLightIndexs ();

		InitDynamicLights ();

		Button btn = GetComponent<Button> ();
		btn.onClick.AddListener (SwitchLights);
	}

	private void InitLightIndexs()
	{
		string text= gameObject.GetComponentInChildren<Text>().text;

		string []strControlLightIndexs= text.Split (' ');
		ControlLightIndexs = new int[strControlLightIndexs.Length];

		for(int id= 0; id< ControlLightIndexs.Length; ++id)
		{
			ControlLightIndexs [id] = int.Parse (strControlLightIndexs [id])-1;
		}
	}

	private void InitDynamicLights()
	{
		DynamicLights = new DynamicLight2D.DynamicLight[Lights.Length];

		for(int id= 0; id< Lights.Length; ++id)
		{
			DynamicLights[id]= Lights [id].GetComponentInChildren<DynamicLight2D.DynamicLight> ();
		}
	}

	public void SwitchLights()
	{
		for(int id= 0; id< ControlLightIndexs.Length; ++id)
		{
			SwitchLight (ControlLightIndexs[id]);
		}
	}

	private void SwitchLight(int id)
	{
		Vector3 position= DynamicLights [id].transform.position;

		if (position.y < 40) 
		{
			DynamicLights [id].transform.position+= UpDistance;
		} 
		else
		{
			DynamicLights [id].transform.position-= UpDistance;
		}
	}
}
