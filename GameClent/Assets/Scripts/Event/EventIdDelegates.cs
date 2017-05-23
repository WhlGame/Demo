using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EventID
{
    None = -1,
    Test0 = 0,
    Test1 = 1,
    Test2 = 2,
    Count,
}
public delegate void EventCallback(EventArg arg);

public class EventIdDelegates
{
    public EventID id;
    public List<EventCallback> ecbs = new List<EventCallback>();
    public void RegisterEvent(EventCallback cb)
    {
        if (!ecbs.Contains(cb))
        {
            ecbs.Add(cb);
        }
    }
    public void DeletEvent(EventCallback cb)
    {
        if (ecbs.Contains(cb))
        {
            ecbs.Remove(cb);
        }
    }
}
