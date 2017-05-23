using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMgr : Singleton<EventMgr>
{
    Dictionary<EventID, EventIdDelegates> edsDic = new Dictionary<EventID, EventIdDelegates>();

    public void Callback(EventID id, EventArg arg)
    {
        if (!edsDic.ContainsKey(id)) return;
        for (int i = 0; i < edsDic[id].ecbs.Count; i++)
        {
            if (edsDic[id].ecbs[i] != null)
                edsDic[id].ecbs[i](arg);
        }
    }
    public void RegisterEvent(EventID id, EventCallback cb)
    {
        if (!edsDic.ContainsKey(id))
        {
            EventIdDelegates eds = new EventIdDelegates();
            eds.id = id;
            edsDic.Add(id, eds);
        }
        edsDic[id].RegisterEvent(cb);
    }
    public void DeletEvent(EventID id, EventCallback cb)
    {
        if (!edsDic.ContainsKey(id))
        {

            return;
        }
        edsDic[id].DeletEvent(cb);
    }
}
