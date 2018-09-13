﻿using System.Collections;
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

    public float CameraBorderDistanceEndPointX = 2.0f;

    public float EndPointX = 19.0f;

    private Vector3 LeftPoint;

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

        PuckBall.transform.position = Player.transform.position - new Vector3(2, 0, 0);

        LeftPoint = PuckBall.transform.position;

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

        //print("Player.transform.position.x:" + Player.transform.position.x + " " + "EndPointX: " + EndPointX);

        if (Player.transform.position.x >= EndPointX  || PuckBall.transform.position.x>= EndPointX)
        {
            SwitchLevelAnimation.SetActive(true);
            //Invoke("ChangeScene", 0.1f);

            return;
        }
    }

    public void ChangeScene()
    {
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
        }
        else if(1 == idx)
        {
            CaremaObject.GetComponent<CameraControl>().lookGameObject = PuckBall;
        }
    }

    public void ReStart()
    {
        Invoke("ReStartScene", 0.2f);
    }

    private void ReStartScene()
    {
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
        print("GameObject onEnter :" + gameObject.name + "  " + "onEnter :" + g.name);

        if (g.transform.root.gameObject == Player || g.transform.root.gameObject == PuckBall)
        {
            GameManager._instance.ReStart();

            return;
        }
    }

    public float GetLeftCameraBorder()
    {
        return LeftPoint.x + CameraBorderDistanceEndPointX;
    }

    public float GetRightCameraBorder()
    {
        return EndPointX - CameraBorderDistanceEndPointX;
    }
}