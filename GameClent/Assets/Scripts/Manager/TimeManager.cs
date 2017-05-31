using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 时间管理，可以分别控制UI和Game的deltaTime
/// </summary>
public class TimeManager : Singleton<TimeManager>
{
    private bool resertUITime = true;
    private bool resertGMTime = true;
    private float uiDeltaTime;
    public float UIDeltaTime
    {
        private set
        {
            uiDeltaTime = value;
        }
        get
        {
            return uiDeltaTime;
        }
    }
    private float gmDeltaTime;
    public float GMDeltaTime
    {
        private set
        {
            gmDeltaTime = value;
        }
        get
        {
            return gmDeltaTime;
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
        deltaTime = Time.realtimeSinceStartup - lastTimeStamp;
        lastTimeStamp = Time.realtimeSinceStartup;

        if (resertUITime)
        {
            UIDeltaTime = deltaTime;
        }
        if (resertGMTime)
        {
            GMDeltaTime = deltaTime;
        }
    }
}
