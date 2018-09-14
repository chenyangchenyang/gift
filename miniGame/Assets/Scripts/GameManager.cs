﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameManager : MonoBehaviour
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

    public GameObject BackGroundAudio;

    public GameObject PlayerDeathAnimation;

    private Vector3 LeftPoint;

    private AudioSource FootAudioSource;

    private AudioSource PuckSkillAudioSource;

    [HideInInspector]
    public AudioSource BgAudioSource;
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

        BgAudioSource= BackGroundAudio.GetComponent<AudioSource>();      
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
        Invoke("ReStartScene", 5.0f);
    }

    private void ReStartScene()
    {
        GlobalTool.BgAudioTime = BgAudioSource.time;

        GlobalTool.BgClipName = BgAudioSource.clip.name;

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
        GameObject collisionGameObject = g.transform.root.gameObject;

        if (collisionGameObject == Player || collisionGameObject == PuckBall)
        {
            PlayerDeathAnimation.transform.position = collisionGameObject.transform.position;

            collisionGameObject.transform.Translate(0, 10000.0f, 0);
            collisionGameObject.transform.position = new Vector3(collisionGameObject.transform.position.x, collisionGameObject.transform.position.y + 10000.0f,
                collisionGameObject.transform.position.z);
            //collisionGameObject.SetActive(false);

            PlayerDeathAnimation.SetActive(true);

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

    public void AdjustAudioInTime(AudioSource audioSource, float time, bool IsDown)
    {
        SetAdjustAudio(audioSource, time, IsDown);

        StartAdjustAudio();
    }

    public void ReStartAudio(AudioSource BgAudioSource, string path)
    {
        if (GlobalTool.BgClipName == null || GlobalTool.BgClipName.Equals(""))
        {
            return;
        }

        BgAudioSource.time = GlobalTool.BgAudioTime;

        string clipName = path + GlobalTool.BgClipName;

        print("clipName:" + clipName);

        AudioClip clip = Resources.Load<AudioClip>(clipName);

        print("clipName clip:" + clipName);

        BgAudioSource.clip = clip;

        BgAudioSource.Play();
    }
}

public partial class GlobalTool
{
    static public float BgAudioTime = 0.0f;
    static public string BgClipName;
}

public partial class GameManager
{
    private AudioSource MySubAudioSource;
    private float AudioDelteTime;
    private int AudioVolumAdjustCount;
    private float AudioEachAdjustTime;
    private float AudioEachAdjustValue;

    private void SetAdjustAudio(AudioSource audioSource, float time, bool IsDown)
    {
        MySubAudioSource    = audioSource;
        AudioDelteTime   = time;

        AudioVolumAdjustCount= 20;

        AudioEachAdjustTime = time / AudioVolumAdjustCount;
        
        if(IsDown)
        {
            AudioEachAdjustValue = -MySubAudioSource.volume / AudioVolumAdjustCount;
        }
        else
        {
            AudioEachAdjustValue = (1- MySubAudioSource.volume) / AudioVolumAdjustCount;
        }
    }

    private void StartAdjustAudio()
    {
        StartCoroutine(RunAdjustBgAudio());
    }

    IEnumerator RunAdjustBgAudio()
    {
        while (MySubAudioSource.volume > 0 && MySubAudioSource.volume< 1.0f)
        {
            print("MyAudioSource.volume:" + MySubAudioSource.volume);

            MySubAudioSource.volume += AudioEachAdjustValue;

            yield return new WaitForSeconds(AudioEachAdjustTime);
        }
    }
}