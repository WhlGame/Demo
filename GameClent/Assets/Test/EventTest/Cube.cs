using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        CubeEventArg ea = new CubeEventArg();
        ea.st = "OnDisable";
        ea.num = 1;
        EventMgr.I.Callback(EventID.Test0, ea);
    }

    private void OnEnable()
    {
        CubeEventArg ea = new CubeEventArg();
        ea.st = "OnEnable";
        ea.num = 0;
        EventMgr.I.Callback(EventID.Test0, ea);
    }

}
