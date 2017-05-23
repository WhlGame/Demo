using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lister : MonoBehaviour
{


    private void Kkk(EventArg arg)
    {
        Debuger.GameLog((arg as CubeEventArg).st);
        Debuger.GameLog((arg as CubeEventArg).num);
    }

    private void OnEnable()
    {
        EventMgr.I.RegisterEvent(EventID.Test0, Kkk);

    }

    private void OnDisable()
    {
        EventMgr.I.DeletEvent(EventID.Test0, Kkk);
    }


}
