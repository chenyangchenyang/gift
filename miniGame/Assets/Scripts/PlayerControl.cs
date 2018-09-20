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
        for (int i = 0; i < transform.GetChild(0).childCount; ++i)
        {
            transform.GetChild(0).GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = GlobalTool.spriteColor;
        }

        if (gameObject == GameManager._instance.Player)
        {
            if (GlobalTool.reborn)
            {
                GlobalTool.reborn = false;
                GameManager._instance.rebornAnim.SetActive(true);
                GameManager._instance.rebornAnim.transform.position = GameManager._instance.Player.transform.position + new Vector3(0, -1f, 0);
                Invoke("HideRebornAnimation", 1.5f);
                GameManager._instance.Player.GetComponent<PlayerControl>().PauseMove();
                for (int i = 0; i < transform.GetChild(0).childCount; ++i)
                {
                    print(i);
                    transform.GetChild(0).GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                }
                GameManager._instance.ReleaseControl();
            }
        }
        
    }

    void HideRebornAnimation()
    {
        GameManager._instance.rebornAnim.transform.position = new Vector3(1000, 1000, 0);
        GameManager._instance.rebornAnim.SetActive(false);
        GameManager._instance.GetControl();
        for (int i = 0; i < GameManager._instance.Player.transform.GetChild(0).childCount; ++i)
        {
            GameManager._instance.Player.transform.GetChild(0).GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = GlobalTool.spriteColor;
        }
        GameManager._instance.Player.GetComponent<PlayerControl>().StartMove();
    }

    void Update ()
    {
        GetComponent<Animator>().SetFloat("Speed", GlobalTool.animSpeed);
        var rb = GetComponent<Rigidbody2D>();
        if (move)
        {
            speed += Time.deltaTime * addSpeed * Mathf.Log(SpeedStand[0] - speed + 2);
            if (speed < 0)
            {
                speed = 0;
            }
            rb.sharedMaterial.friction = 1;
            rb.position = rb.position + speed * dir * Time.deltaTime;
        }   
        else
        {
            if (gameObject == GameManager._instance.PuckBall)
            {
                speed = SpeedStand[0];
            }
            else
            {
                speed = SpeedStand[0];
            }
            rb.sharedMaterial.friction = 1;
        }
        if (gameObject == GameManager._instance.PuckBall) return;
        if (transform.position.y < -100)
        {
            GameManager._instance.ReStart();
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
