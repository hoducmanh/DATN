using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    public void PlayVideo(string urlLink)
    {
        player.url = urlLink;
        player.Play();
    }
}
