using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public bool move = false;
    public Vector2 dir;
    public Vector2 lastPosition;
    public Vector2 lastDir;
	private Text TextComponent;
    [SerializeField]
    private float speed = 1;

    private float lastSpeed = 0;

    void Start () 
	{
        lastPosition = gameObject.GetComponent<Rigidbody2D>().position;
	}
	

	void Update () 
	{
        var rb = GetComponent<Rigidbody2D>();
        if (move)
        {
            rb.sharedMaterial.friction = 1;
            rb.position = rb.position + speed * dir * Time.deltaTime;
        }   
        else
        {
            rb.sharedMaterial.friction = 1;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    public void PauseMove()
    {
        move = false;

        lastSpeed = speed;

        speed = 0;

        GetComponent<Animator>().SetBool("Walking", false);
    }

    public void StartMove()
    {
        speed = lastSpeed;
    }
}
