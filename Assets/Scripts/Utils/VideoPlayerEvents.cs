using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoPlayerEvents : MonoBehaviour
{
    public VideoPlayer video;

    public UnityEvent OnVideoStop;

    private void Start()
    {
        video.loopPointReached += Finish;
    }

    void Finish(VideoPlayer vp)
    {
        OnVideoStop?.Invoke();
    }
}
