using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectViewBase
{
    public Transform mTransform { get; private set; }
    protected GameObject stageObject;
    public virtual void init(string resourcePath)
    {
        Object go = ResourcesManager.I.LoadObject(resourcePath);
        stageObject = GameObject.Instantiate(go) as GameObject;
        mTransform = stageObject.transform;
    }
    public virtual void Move(Vector3 speed)
    {
        mTransform.position += speed;
    }
    public virtual void Update()
    {

    }
}
