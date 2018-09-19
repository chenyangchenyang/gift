using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDefs : MonoBehaviour {

    public float PuckTimeLength = 2;
    [HideInInspector]
    public float puckTime = 0;
    public float coolDown = 2;
    public float runtimeCooldown;
	// Use this for initialization
	void Start () {
        GlobalTool.Init();
	}
	
	// Update is called once per frame
	void Update () {
        runtimeCooldown -= Time.deltaTime;
        puckTime += Time.deltaTime;
        if (GlobalTool.puckState == 1 && puckTime >= PuckTimeLength)
        {
            GotoPuckBall();
        }
	}

    public void Puck()
    {
        if (runtimeCooldown > 0) return;
        if(null == GlobalTool.puckBall)
        {
            print("null == GlobalTool.puckBall");

            return;
        }

        if (GlobalTool.puckState == 0)
        {
            GlobalTool.ReleasePuckBall();

            SetPuckState(1);            

            puckTime = 0;
            // Update() 2秒后会自动调用 GotoPuckBall()
           
        }
        else
        {
            GotoPuckBall();
        }

        
    }

    public void GotoPuckBall()
    {
        runtimeCooldown = coolDown;
        if (GlobalTool.puckState == 0)
            return;
        GlobalTool.GotoPuckBall();
        SetPuckState(0);
    }

    private void ChangeCameraLookAt()
    {
        GameManager._instance.ChangeCameraLookAt(GlobalTool.puckState);
    }

    public void ReleaseControlPuck()
    {
        GlobalTool.puckBall = null;
    }

    public void GetControlPuck()
    {
        GlobalTool.puckBall = GameManager._instance.PuckBall;
    }

    public void SetPuckState(int state)
    {
        GlobalTool.puckState = state;
        ChangeCameraLookAt();
    }
}

public partial class GlobalTool
{
    public static bool woodJump = false;
    public static GameObject puckBall;
    public static GameObject player;
    public static int puckState = 0;
    public static JoyStickControl joyStickControl;
    public static GameObject controlButton;
    public static void Init()
    {
        //puckBall = GameObject.Find("PuckBall");
        //player = GameObject.Find("Player");
        puckBall = GameManager._instance.PuckBall;
        player = GameManager._instance.Player;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("playerBody"), LayerMask.NameToLayer("puck"), true);
        //joyStickControl = GameObject.Find("GlobalHandler").GetComponent<JoyStickControl>();
        joyStickControl= GameManager._instance.GlobalControllerObject.GetComponent<JoyStickControl>();
        controlButton = GameManager._instance.PuckButton;

        //controlButton = GameObject.Find("Button");
    }

    // 创建帕克法球，并使其自动向当前方向行走数秒
    public static void ReleasePuckBall()
    {
        Show(puckBall);
        GameManager._instance.PuckBall.transform.position = GameManager._instance.Player.transform.position;
        PlayerControl playerControl = GameManager._instance.Player.GetComponent<PlayerControl>();
        if (GameManager._instance.Player.transform.GetChild(0).localScale.x > 0)
        {
            GameManager._instance.PuckBall.GetComponent<PlayerControl>().dir = new Vector2(1, 0);
        }
        else
        {

            GameManager._instance.PuckBall.GetComponent<PlayerControl>().dir = new Vector2(-1, 0);
        }
        GameManager._instance.PuckBall.GetComponent<PlayerControl>().move = true;
        GameManager._instance.PuckBall.transform.GetChild(0).localScale = GameManager._instance.Player.transform.GetChild(0).localScale;
        GameManager._instance.ReleaseControl();
        //controlButton.SetActive(false);
    }

    // 将本体移动到帕克法球的位置，使帕克法球消失，交还控制消息
    public static void GotoPuckBall()
    {
        Camera.main.GetComponent<CameraControl>().lookGameObject = GameManager._instance.Player;
        GameManager._instance.Player.transform.position = GameManager._instance.PuckBall.transform.position;
        GameManager._instance.PuckBall.GetComponent<PlayerControl>().move = false;
        GameManager._instance.GetControl();
        //controlButton.SetActive(true);
        Hide(GameManager._instance.PuckBall);
    }

    public static void Hide(GameObject o)
    {
        o.transform.localScale = Vector3.zero;
    }

    public static void Show(GameObject o)
    {
        o.transform.localScale = Vector3.one;
    }

    public static void Blackout()
    {
        var global = GameObject.Find("GlobalHandler");
        global.GetComponent<CameraExtraControl>().Blackout();
    }

    public static void Whiteout()
    {
        var global = GameObject.Find("GlobalHandler");
        global.GetComponent<CameraExtraControl>().WhiteOut();
    }
}
