using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBox : MonoBehaviour {

    // Use this for initialization
    public GameObject[] NextImages;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if("Body" == collision.collider.gameObject.name)
        {
            print(collision.collider.gameObject.name);

            PausePlayerMove();

            //弹出图片
            StartCoroutine(ShowNextImages());

            Destroy(GetComponent<BoxCollider2D>());
        }
    }

   IEnumerator ShowNextImages()
    {
       for(int idx= 0; idx< NextImages.Length; ++idx)
       {
            NextImages[idx].SetActive(true);

            yield return new WaitForSeconds(0.2f);
       }
    }

    private void PausePlayerMove()
    {
        PlayerControl pcl= GameManager._instance.Player.GetComponent<PlayerControl>();

        pcl.PauseMove();
    }
}
