using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    private string url = "http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1";
    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetWWW());
    }
    private IEnumerator GetWWW()
    {
        WWW w = new WWW(url);
        yield return w;
        DateTime dt = GetTime(w.text.Remove(0, 2));
        Debuger.GameLog(dt.ToString("yyyy/MM/dd HH:mm:ss:ffff"));
    }
    /// <summary>
    /// 时间戳转为C#格式时间
    /// </summary>
    /// <param name=”timeStamp”></param>
    /// <returns></returns>
    private DateTime GetTime(string timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        double lTime = double.Parse(timeStamp);
        return dtStart.AddMilliseconds(lTime);
    }
    int times = 0;
    // Update is called once per frame
    void Update()
    {

    }

}
