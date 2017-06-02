using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 时间管理,真实的时间和Time.deltaTime
/// </summary>
public class TimeManager : Singleton<TimeManager>
{

    float timeScale = 1f;
    float keepTimeScale = 1f;
    bool isStop = false;
    public float TimeScale { get { return timeScale; } }
    public float RealTimeSpan { get; private set; }

    public float UIDeltaTime
    {

        get
        {
            return Time.deltaTime;
        }
    }
    public float GMDeltaTime
    {
        get
        {
            return Time.deltaTime;
        }
    }
    private float lastTimeStamp;
    private float deltaTime;
    protected override void Awake()
    {
        base.Awake();
    }
    void Update()
    {
        RealTimeSpan = Time.realtimeSinceStartup - lastTimeStamp;
        lastTimeStamp = Time.realtimeSinceStartup;
    }
    public void SetTimeScale(float scale)
    {
        timeScale = scale;
        keepTimeScale = timeScale;
        if (!isStop)
        {
            Time.timeScale = timeScale;
        }
    }

    public void StopTimeScale()
    {
        if (!isStop)
        {
            keepTimeScale = timeScale;
        }
        Time.timeScale = timeScale = 0f;
        isStop = true;
    }

    public void ResetTimeScaleFromStop()
    {
        timeScale = keepTimeScale;
        Time.timeScale = keepTimeScale;
        isStop = false;
    }
}
