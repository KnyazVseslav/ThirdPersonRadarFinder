using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New event", menuName ="Game event", order = 52)]
public class Event : ScriptableObject
{
    private List<EventListener> eventListeners = new List<EventListener>();

    public Event()
    {
        Debug.Log("Event  CTOR");
    }

    public void RegisterListener(EventListener l)
    {
        eventListeners.Add(l);
    }

    public void UnregisterListener(EventListener l)
    {
        eventListeners.Remove(l);
    }

    public void Occurred(GameObject o)
    {
        foreach (var l in eventListeners)
        {
            Debug.Log("Event.Occurred.foreach l = " + l);
            l.OnEventOccurred(o);
        }
//         for (var i = 0; i < eventListeners.Count; ++i)
//         {
//             Debug.Log("Event.Occurred.for");
//             eventListeners[i].OnEventOccurred();
//         }
    }
}
