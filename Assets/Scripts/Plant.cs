using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantData plantData;
    private SetPlantInfo setPlantinfoScript;

    public PlantData Data { get { return plantData; } }

    void Start()
    {
        setPlantinfoScript = GameObject.FindWithTag("PlantCanvas").GetComponent<SetPlantInfo>();
    }

    void OnMouseDown()
    {
        setPlantinfoScript.OpenPlantPanel();
        setPlantinfoScript.plantName.text = plantData.Name;
        setPlantinfoScript.threatLevel.text = plantData.Threat.ToString();
        setPlantinfoScript.plantImg.GetComponent<RawImage>().texture = plantData.Img;
    }
}
