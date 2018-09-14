using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestGlobal : MonoBehaviour
{
	void Start ()
    {
        //Dictionary<string, string> di = new Dictionary<string, string>();

        //di.Add("1", "2");

        //if(di.ContainsKey("1"))
        //{
        //    print("1234");
        //}

        if (GlobalTool.Saves.ContainsKey("1"))
        //if (GlobalTool.HasKey("1"))
        {
            print(SceneManager.GetActiveScene().name+":::123");
        }

        GlobalTool.SetString("1", "2");

        //foreach (var item in GlobalTool.Saves)
        //{

        //    print(item.Key +" "+ item.Value);

        //}

        //if(GlobalTool.Saves.ContainsKey("1"))
        ////if (GlobalTool.HasKey("1"))
        //{
        //    print("1234");
        //}

        //if (GlobalTool.HasKey("1"))
        //{
        //    print("getstring:" + GlobalTool.GetString("1"));
        //}

        //print(GlobalTool.Saves.Count);      

        int nextActiveScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextActiveScene >= SceneManager.sceneCountInBuildSettings)
        {
            return;
        }

        SceneManager.LoadScene(nextActiveScene);
    }
}
