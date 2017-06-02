using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;
public class TweeenTest : MonoBehaviour
{
    public Tween.Method method;
    // Use this for initialization
    void Start()
    {
        TweenTask tTask = new TweenTask(delegate
        {
            TweenWorldPosition t = Tween.Begin<TweenWorldPosition>(gameObject, 3);
            t.from = transform.position;
            t.to = transform.position + Vector3.one * 10;
            t.style = Tween.Style.Loop;
            t.method = method;
            t.Play(true);
            return t;
        });
        //TaskManager.Run(tTask);
        TweenWorldPosition t1 = Tween.Begin<TweenWorldPosition>(gameObject, 3);
        t1.from = Vector3.zero;
        t1.to = new Vector3(1,1,0) * 10;
        t1.style = Tween.Style.Once;
        t1.method = method;
        t1.Play(true);
        Tween1(t1);
    }
    public void Tween1(Tween tween)
    {
        TweenWorldPosition t = Tween.Begin<TweenWorldPosition>(gameObject, 3);
        t.from = Vector3.zero;
        t.to = Vector3.one * 10;
        t.style = Tween.Style.Once;
        t.method = method;
        t.Play(true);
        t.onFinished += Tween1;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
