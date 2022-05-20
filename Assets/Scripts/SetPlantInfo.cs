using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlantInfo : MonoBehaviour
{
    public GameObject plantInfoPanel;
    public GameObject plantImg;
    public Text plantName;
    public Text threatLevel;

    public void OpenPlantPanel()
    {
        plantInfoPanel.SetActive(true);
    }

    public void ClosePlantPanel()
    {
        plantInfoPanel.SetActive(false);
    }
}
