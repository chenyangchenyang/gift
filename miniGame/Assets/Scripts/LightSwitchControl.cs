using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchControl : MonoBehaviour
{
	private float UpDistance = 100.0f;

	public GameObject[] Light2Ds;

	// Use this for initialization
	void Start () 
	{
		if (!InVaild()) 
		{
			return;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!Input.GetMouseButtonDown (0) || !InVaild()) 
		{
			return;
		}

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 

		if(null != hit.collider)
		{
			if(hit.collider.gameObject== gameObject)
			{
				ChangePostion ();
			}
		}
	}

	bool InVaild()
	{
		bool flag = !(null == Light2Ds || 0 == Light2Ds.Length);

		return flag;
	}

	void ChangePostion()
	{
		foreach(GameObject Light2D in Light2Ds)
		{
			if (Light2D.transform.position.y < 50) 
			{
				Vector3 Position = Light2D.transform.position;

				Vector3 newPos = Position;
				newPos.y += UpDistance;
				Light2D.transform.position = newPos;

			} 
			else 
			{
				Vector3 Position = Light2D.transform.position;

				Vector3 newPos = Position;
				newPos.y -= UpDistance;
				Light2D.transform.position = newPos;
			}
		}
	}
}
