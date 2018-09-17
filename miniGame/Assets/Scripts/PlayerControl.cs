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
    private float speed = 1;
    [SerializeField]
    private float addSpeed = 0;

    [SerializeField]
    private float startSpeed;
    private float lastSpeed;

    void Start () 
	{
        lastSpeed = speed;
        lastPosition = gameObject.GetComponent<Rigidbody2D>().position;
	}
	

	void Update () 
	{
        speed += Time.deltaTime * addSpeed * Mathf.Log(startSpeed - speed + 2);
        if (speed < 0)
        {
            speed = 0;
        }
        var rb = GetComponent<Rigidbody2D>();
        if (move)
        {
            rb.sharedMaterial.friction = 1;
            rb.position = rb.position + speed * dir * Time.deltaTime;
        }   
        else
        {
            speed = startSpeed;
            rb.sharedMaterial.friction = 1;
        }


    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;
        if (gameObject != GameManager._instance.PuckBall && transform.position.y < -100)
        {
            GameManager._instance.ReStart();
        }
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

    public void PlayFootStep()
    {
        if(gameObject != GameManager._instance.Player)
        {
            return;
        }

        GameManager._instance.PlayFootStep();
    }
}
