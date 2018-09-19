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

    [HideInInspector]
    public float speed = 1;
    [SerializeField]
    private float addSpeed = 0;

    private float lastSpeed;


    public float[] SpeedStand= new float[3];
    public float[] SpeedAnimation = new float[3] { 1, 1, 1 };
    public Color[] SpriteColor = new Color[3];

    void Start () 
	{
        lastSpeed = speed;
        lastPosition = gameObject.GetComponent<Rigidbody2D>().position;    

        if(0 == GlobalTool.CurDeathCount)
        {
            GlobalTool.CurStandSpeed = SpeedStand[0];
        }
        GetComponent<Animator>().SetFloat("Speed", GlobalTool.animSpeed);  
        for (int i = 0; i < transform.GetChild(0).childCount; ++i)
        {
            transform.GetChild(0).GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = GlobalTool.spriteColor;
        }
    }

	void Update () 
	{   
        var rb = GetComponent<Rigidbody2D>();
        if (move)
        {
            speed += Time.deltaTime * addSpeed * Mathf.Log(GlobalTool.CurStandSpeed - speed + 2);
            if (speed < 0)
            {
                speed = 0;
            }
            rb.sharedMaterial.friction = 1;
            rb.position = rb.position + speed * dir * Time.deltaTime;
        }   
        else
        {
            speed = SpeedStand[0];
            rb.sharedMaterial.friction = 1;
        }

        UpdateSpeed();
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


    private void UpdateSpeed()
    {
        //print("CurStandSpeed : "+ CurStandSpeed);

        if(speed > GlobalTool.CurStandSpeed)
        {
            speed = GlobalTool.CurStandSpeed;
        }
    }


    private float StepPerMS;
    private float FinialV;
    public void AdjustSpeed(float stepPerMS, float finalV)
    {
        StepPerMS = stepPerMS;
        FinialV   = finalV;
        StartCoroutine(OnAdjustSpeed());
    }
    private IEnumerator OnAdjustSpeed()
    {
        if(StepPerMS< 0)
        {
            while(speed > FinialV)
            {
                speed += StepPerMS;

                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            while (speed < FinialV)
            {
                speed += StepPerMS;

                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}

public partial class GlobalTool
{
    public static int CurDeathCount = 0;
    public static float animSpeed = 1;
    public static Color spriteColor = Color.white;
    public static float CurStandSpeed;
    public static void SetCurDeathCount(int idx)
    {
        PlayerControl player= GameManager._instance.Player.GetComponent<PlayerControl>();
        
        if(player.SpeedStand!= null && idx< player.SpeedStand.Length && idx>= 0)
        {
            CurStandSpeed = player.SpeedStand[idx];
        }        
        if (idx >= 0 && idx < player.SpeedAnimation.Length)
        {
            animSpeed = player.SpeedAnimation[idx];
            spriteColor = player.SpriteColor[idx];
        }
    }
}
