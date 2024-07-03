using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    public void PlayVideo(string urlLink)
    {
        Debug.Log(Application.dataPath);
#if !UNITY_EDITOR
        //string path = "file://C:/Manh/Build/Newfolder/Video/A.mov";
        string path = Application.dataPath + urlLink;
        player.url = path;
        player.Prepare();
        player.prepareCompleted += Player_prepareCompleted;

#else

        var link = "Assets/Game" + urlLink; 
        player.url = link;
        player.Prepare();
        player.prepareCompleted += Player_prepareCompleted;
#endif
    }

    private void Player_prepareCompleted(VideoPlayer source)
    {
        player.Play();
    }
}
