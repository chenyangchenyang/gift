using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoChange : MonoBehaviour
{
    public VideoPlayer video;

    public void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    public void Update()
    {
        if(video.frame>0  && !video.isPlaying)
        {
            string name = "Level1";

            SceneManager.LoadScene(name);
        }
    }

}
