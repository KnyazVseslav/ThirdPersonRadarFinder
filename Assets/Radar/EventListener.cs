using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomEvent : UnityEvent<GameObject> { };

public class EventListener : MonoBehaviour
{
    public Event gameEvent;
    public CustomEvent reactionEvent = new CustomEvent();

//     void Start()
//     {
//         Debug.Log("Radar Start");
//         gameEvent.RegisterListener(this);
//     }

    void OnEnable()
    {
        Debug.Log("EventListener OnEnable");
        gameEvent.RegisterListener(this);
    }

    void OnDisable()
    {
        Debug.Log("EventListener OnDisable");
        gameEvent.UnregisterListener(this);
    }

    public void OnEventOccurred(GameObject o)
    {
        Debug.Log("EventListener OnEventOccurred");
        reactionEvent.Invoke(o);
    }
}
