using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomAD : MonoBehaviour
{
    public VideoPlayer Videoplayer;
    public VideoClip[] Vids = new VideoClip[22];
    private GameObject ADWindowClone;

    
    private void Awake()
    {
        PlayRandomVid(Random.Range(0, Vids.Length));
    }

    public void Update()
    {
        if (PauseMenu.GameIsPaused) 
        {
            Videoplayer.Pause();
        }
        else
        {
            Videoplayer.Play();
        }
    }

    public void PlayRandomVid(int ID)
    {
       Videoplayer.clip = Vids[ID];
    }

}
