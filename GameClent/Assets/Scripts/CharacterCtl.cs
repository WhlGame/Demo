using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;
public class CharacterCtl : StageObjectCtlBase
{
    FSM f = new FSM();
    public Transform mTransform
    {
        get;
        private set;
    }
    protected CharacterModel mModel;
    protected CharacterView mView;
    public void Init(CharacterModel model)
    {
        mModel = model;
        mView = new CharacterView();
        mView.init(model.resourcePath);
        mView.mTransform.parent = mTransform;
    }
    void Awake()
    {
        mTransform = gameObject.transform;
    }
    void Start()
    {
        f.addState("Idle", Idle());
        f.addState("Move", Move());
        f.addState("Atk", Atk());
        f.init("Idle");
    }
    State Idle()
    {
        StateWithEventMap state = new StateWithEventMap();
        state.onStart += delegate
         {
             mView.Idel();
         };
        state.addEvent("move", "Move");
        state.addEvent("atk", "Atk");
        return state;
    }
    State Move()
    {
        bool moveEnd = false;
        StateWithEventMap state = new StateWithEventMap();
        state.onStart += delegate
        {
            mView.Move();
            moveEnd = false;
            Task t = new Task();
            t.isOver += delegate
            {
                return moveEnd;
            };
            TaskManager.AddUpdate(t, UpdateMove);
            //TaskManager.PushBack(t, delegate { f.post("atk"); });
            TaskManager.Run(t);
        };
        state.onOver += delegate { moveEnd = true; };



        state.addEvent("idle", "Idle");
        state.addEvent("atk", "Atk");
        return state;
    }
    public void UpdateMove(float t)
    {
        mTransform.position += Vector3.one * mModel.speed * t;
    }
    State Atk()
    {
        StateWithEventMap state = new StateWithEventMap();
        state.onStart += delegate
        {
            mView.Atk();
        };
        state.addEvent("move", "Move");
        state.addEvent("idle", "Idle");
        return state;
    }
    void Update()
    {
        mView.Update(Time.deltaTime);
        if (Input.GetKey(KeyCode.M))
        {
            f.post("move");
        }
        if (Input.GetKey(KeyCode.A))
        {
            f.post("atk");
        }
        if (Input.GetKey(KeyCode.I))
        {
            f.post("idle");
        }
    }

}
