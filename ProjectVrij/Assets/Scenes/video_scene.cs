using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class video_scene : MonoBehaviour
{
    public double time;
    public double currentTime;
    public VideoPlayer vid;
    // Use this for initialization
    void Start()
    {

        time = vid.clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = vid.time;
        if (currentTime >= time)
        {
            Debug.Log("done");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
