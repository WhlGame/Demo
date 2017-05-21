using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Debuger.GameLog("3333333333");
        Debuger.SetLogEnable(false);
        Debuger.GameLog("4444444444");
        //it.set
        Debug.Log("111111");
        Debug.logger.logEnabled = false;
        Debug.Log("22222222");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
