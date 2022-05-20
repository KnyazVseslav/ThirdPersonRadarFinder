using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Event droppedEvt;
    public Event pickedUpEvent;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Item  Start");
        droppedEvt.Occurred(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickedUpEvent.Occurred(this.gameObject);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject, 5);
        }
    }
}
