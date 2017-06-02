using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : StageObjectViewBase
{
    private string state;

    public void Idel()
    {
        state = "Idel";

    }
    public void Move()
    {
        state = "Move";
    }
    public void Atk()
    {
        state = "Atk";

    }

    public void Update(float deltaTime)
    {
        Debuger.GameLog(deltaTime + state);
    }
}
