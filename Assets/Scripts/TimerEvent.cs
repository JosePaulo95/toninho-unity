using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    public float timer = 1f;
    public UnityEvent OnFinishTimer;

    public void StartTimer()
    {
        CancelInvoke();
        Invoke(nameof(Finish), timer);
    }

    void Finish()
    {
        OnFinishTimer?.Invoke();
    }
}
