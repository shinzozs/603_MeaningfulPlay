using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomAD : MonoBehaviour
{
    public VideoPlayer Videoplayer;
    public VideoClip[] Vids = new VideoClip[22];

    private void Awake()
    {
        PlayRandomVid(Random.Range(0, Vids.Length));
    }

    public void PlayRandomVid(int ID)
    {
       Videoplayer.clip = Vids[ID];
    }

}
