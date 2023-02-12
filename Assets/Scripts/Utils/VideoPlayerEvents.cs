using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoPlayerEvents : MonoBehaviour
{
    public VideoPlayer video;

    public UnityEvent OnVideoStop;

    void Awake () {
        video.url = System.IO.Path.Combine (Application.streamingAssetsPath,"intro.mp4"); 
    }

    private void Start()
    {
        video.loopPointReached += Finish;
    }

    void Finish(VideoPlayer vp)
    {
        OnVideoStop?.Invoke();
    }
}
