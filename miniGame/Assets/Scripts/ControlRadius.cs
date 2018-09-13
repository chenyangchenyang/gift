using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRadius : MonoBehaviour {


	private Slider slider;


	void Start () 
	{
		slider = GetComponent<Slider>();

		slider.onValueChanged.AddListener (change);
	}
	

	void Update () 
	{
		
	}

	private void change(float key)
	{
		print (key.ToString ());
	}
}
