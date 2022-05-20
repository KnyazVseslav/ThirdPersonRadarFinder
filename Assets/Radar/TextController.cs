using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    Text textCmpnt;

    // Start is called before the first frame update
    void Start()
    {
        textCmpnt = GetComponent<Text>();
        textCmpnt.enabled = false;
    }

    public void ItemPickedUpEventReaction(GameObject o)
    {
        textCmpnt.text = "You picked up an item!!!";
        textCmpnt.enabled = true;
        Invoke("HideText", 2);
    }

    void HideText()
    {
        textCmpnt.enabled = false;
    }
}
