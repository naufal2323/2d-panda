using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }
}
