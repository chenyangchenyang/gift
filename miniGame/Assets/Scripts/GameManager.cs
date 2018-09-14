using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameObject Player;

    public GameObject PlayerControlUI;

    public GameObject PuckBall;

    public GameObject GlobalControllerObject;

    public GameObject CaremaObject;

    public GameObject LightRoot;

    public GameObject PuckButton;

    public GameObject SwitchLevelText;

    public GameObject SwitchLevelAnimation;

    public GameObject StartLevelAnimation;

    public float LeftCameraBorderDistanceEndPointX = 2.0f;

    public float RightCameraBorderDistanceEndPointX = 10.0f;

    public float EndPointX = 19.0f;

    public float BgAudioVolumToZeroDeleta = 2.0f;

    public AudioClip []FootStepAudios;

    public AudioClip BgAudioClip;

    private Vector3 LeftPoint;

    private AudioSource FootAudioSource;

    [HideInInspector]
    public AudioSource BgAudioSource;

    private AudioSource PuckSkillAudioSource;

    [HideInInspector]
    public string PlayerPosition = "PlayerPosition";
    [HideInInspector]
    public string CameraDistancePlayer = "CameraDistancePlayer";

    private void Awake()
    {      
         _instance = this;
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        InitializedLight();

        InitializedPosition();

        PuckBall.transform.position = Player.transform.position - new Vector3(2, 0, 0);

        LeftPoint = PuckBall.transform.position;

        InitializedAudioSource(); 
    }

    private void InitializedAudioSource()
    {
        PuckSkillAudioSource = GetComponent<AudioSource>();
        PuckSkillAudioSource.Stop();

        FootAudioSource = Player.GetComponent<AudioSource>();      

        BgAudioSource = CaremaObject.GetComponent<AudioSource>();
        BgAudioSource.clip = BgAudioClip;
        BgAudioSource.time = GlobalTool.BgAudioTime;
        BgAudioSource.Play();
    }

    private void InitializedPosition()
    {
        if(!GlobalTool.Saves.ContainsKey(PlayerPosition))
        {
            return;
        }        
        string playerPositionStr  = GlobalTool.GetString(PlayerPosition);
        string cameraDistanceStr  = GlobalTool.GetString(CameraDistancePlayer);

        print("playerPositionStr :"+ playerPositionStr);

        Player.transform.position = String2Vector3(playerPositionStr);
        CaremaObject.transform.position = Player.transform.position + String2Vector3(cameraDistanceStr);
    }

    void Update()
    {

        if (PuckBall.transform.position.x < LeftPoint.x)
        {
            PuckBall.transform.position = LeftPoint;

            return;
        }

        if (Player.transform.position.x < LeftPoint.x)
        {
            Player.transform.position = LeftPoint;

            return;
        }
      

        if (Player.transform.position.x >= EndPointX  || PuckBall.transform.position.x>= EndPointX)
        {
            SwitchLevelAnimation.SetActive(true);

            return;
        }
    }

    public void ChangeScene()
    {
        GlobalTool.DeleteAll();

        GlobalTool.BgAudioTime = 0.0f;

        int nextActiveScene = SceneManager.GetActiveScene().buildIndex+ 1;

        if (nextActiveScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextActiveScene = 0;
        }
        
        SceneManager.LoadScene(nextActiveScene);
    }

    public void ChangeCameraLookAt(int idx)
    {
        if(0 == idx)
        {
            CaremaObject.GetComponent<CameraControl>().lookGameObject = Player;

            PuckSkillAudioSource.Stop();
        }
        else if(1 == idx)
        {
            CaremaObject.GetComponent<CameraControl>().lookGameObject = PuckBall;

            PuckSkillAudioSource.Play();
        }
    }

    public void ReStart()
    {
        Invoke("ReStartScene", 0.2f);
    }

    private void ReStartScene()
    {
        GlobalTool.BgAudioTime = BgAudioSource.time;

        string name = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(name);
    }


    private void InitializedLight()
    {
        if(null== LightRoot)
        {
            return;
        }

        DynamicLight2D.DynamicLight[] Lights = LightRoot.GetComponentsInChildren<DynamicLight2D.DynamicLight>();

        foreach (DynamicLight2D.DynamicLight light in Lights)
        {
            // Add listeners
            light.OnEnterFieldOfView += onEnter;
        }
    }

    private void onEnter(GameObject g, DynamicLight2D.DynamicLight light)
    {
        if (g.transform.root.gameObject == Player || g.transform.root.gameObject == PuckBall)
        {
            GameManager._instance.ReStart();

            return;
        }
    }

    public float GetLeftCameraBorder()
    {
        return LeftPoint.x + LeftCameraBorderDistanceEndPointX;
    }

    public float GetRightCameraBorder()
    {
        return EndPointX - RightCameraBorderDistanceEndPointX;
    }

    public Vector3 String2Vector3(string v3)
    {
        string []vs= v3.Split(' ');

        float x = float.Parse(vs[0]);
        float y = float.Parse(vs[1]);
        float z = float.Parse(vs[2]);

        return new Vector3(x, y, z);
    }

    public string Vector3ToString(Vector3 v)
    {
        string str= v.x.ToString() + " " + v.y.ToString() + " " + v.z.ToString();
        return str;
    }


    public void PlayFootStep()
    {
        int clipIdx= Random.Range(0, FootStepAudios.Length);

        FootAudioSource.clip = FootStepAudios[clipIdx];
        FootAudioSource.Play();
    }
}

public partial class GlobalTool
{
    static public float BgAudioTime = 0.0f;
}