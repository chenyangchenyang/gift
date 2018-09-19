using System.Collections;
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
    public string CameraPosition = "CameraPosition";


    private void Awake()
    {      
         _instance = this;
    }

    private void Start()
    {
        if(!GlobalTool.HasBG())
        {
            BackGroundAudio.GetComponent<AudioSource>().gameObject.SetActive(false);
        }      

        Initialized();
        Camera.main.GetComponent<CameraControl>().lookGameObject = GameObject.Find("Player");
    }

    private void Initialized()
    {
        InitializedLight();
         
        InitializedPosition();

        //if(null != Player  &&  null != PuckBall)
        {
            PuckBall.transform.position = Player.transform.position - new Vector3(2, 0, 0);

            LeftPoint = PuckBall.transform.position;
        }       

        InitializedAudioSource();
    }

    private void InitializedAudioSource()
    {
        PuckSkillAudioSource = GetComponent<AudioSource>();
        PuckSkillAudioSource.Stop();

        if(null != Player)
        {
            FootAudioSource = Player.GetComponent<AudioSource>();
        }        

        BgAudioSource= BackGroundAudio.GetComponent<AudioSource>();      
    }

    private void InitializedPosition()
    {
        if(!GlobalTool.Saves.ContainsKey(PlayerPosition))
        {
            return;
        }        
        string playerPositionStr  = GlobalTool.GetString(PlayerPosition);
        string cameraPositionStr = GlobalTool.GetString(CameraPosition);

        print("playerPositionStr :"+ playerPositionStr);
        print("cameraPositionStr :" + cameraPositionStr);
        Player.transform.position = String2Vector3(playerPositionStr);
        CaremaObject.transform.position = String2Vector3(cameraPositionStr);

        print("GlobalTool.TotalDeathCount: "+GlobalTool.TotalDeathCount);

        GlobalTool.ShowFistDeathImg();
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

        //if(null == PuckBall || null == Player)
        //{
        //    return;
        //}

        if (Player.transform.position.x >= EndPointX  || PuckBall.transform.position.x>= EndPointX)
        {
            SwitchLevelAnimation.SetActive(true);

            return;
        }
    }

    public void ChangeScene()
    {
        GlobalTool.DeleteAll();

        GlobalTool.ChangeScene();

        //int nextActiveScene = SceneManager.GetActiveScene().buildIndex+ 1;

        //if (nextActiveScene >= SceneManager.sceneCountInBuildSettings)
        //{
        //    nextActiveScene = 0;
        //}
        
        //SceneManager.LoadScene(nextActiveScene);
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {
            GlobalTool.nextScene = 2;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level2Outside"))
        {
            SceneManager.LoadScene("Level2Inside");
            return;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level2Inside"))
        {
            GlobalTool.nextScene = 3;
        }
        else if (SceneManager.GetActiveScene().name.Contains("Level3") || SceneManager.GetActiveScene().name.Contains("level3"))
        {
            GlobalTool.nextScene = 4;
        }
        else if (SceneManager.GetActiveScene().name.Contains("Level4"))
        {
            SceneManager.LoadScene("Level5");
            return;
        }
        SceneManager.LoadScene("CutScene");
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
        GlobalTool.scene1StartHandled = false;
        Invoke("ReStartScene", 1.03f);
    }

    private void ReStartScene()
    {
        GlobalTool.BgAudioTime = BgAudioSource.time;

        GlobalTool.BgClipName = BgAudioSource.clip.name;

        GlobalTool.ReStart();

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
            print("onEnter collisionGameObject :"+ collisionGameObject.name);

            PlayerDeathAnimation.transform.position = collisionGameObject.transform.position;

            collisionGameObject.transform.Translate(0, 10000.0f, 0);

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

        AudioClip clip = Resources.Load<AudioClip>(clipName);

        BgAudioSource.clip = clip;

        BgAudioSource.Play();
    }

    public void ReleaseControl()
    {
        GlobalControllerObject.GetComponent<JoyStickControl>().ReleaseControlPlayer();
        GlobalControllerObject.GetComponent<GlobalDefs>().ReleaseControlPuck();
    }

    public void GetControl()
    {
        GlobalControllerObject.GetComponent<JoyStickControl>().GetControlPlayer();
        GlobalControllerObject.GetComponent<GlobalDefs>().GetControlPuck();
    }
}

public partial class GlobalTool
{
    static public float BgAudioTime = 0.0f;
    static public string BgClipName;

    static public int TotalDeathCount = 0;

    static public void ChangeScene()
    {
        BgAudioTime = 0.0f;
        BgClipName = "";
        CurDeathCount = 0;
    }

    static public void ReStart()
    {
        ++CurDeathCount;

        SetCurDeathCount(CurDeathCount);

        ++TotalDeathCount;
    }

    static public void ShowFistDeathImg()
    {
        if(1 == TotalDeathCount)
        {
            GameManager._instance.Player.GetComponent<FirstDeath>().ActiveImg();
        }
    }
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
        if(MySubAudioSource.volume> 0.001f)
        {
            MySubAudioSource.volume -= 0.0001f;
        }
        
        while (MySubAudioSource.volume > 0 && MySubAudioSource.volume< 1.0f)
        {
            print(" RunAdjustBgAudio :" + MySubAudioSource.volume);

            MySubAudioSource.volume += AudioEachAdjustValue;

            yield return new WaitForSeconds(AudioEachAdjustTime);
        }
    }
}