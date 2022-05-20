using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantData", menuName = "Plant Data", order = 51)]
public class PlantData : ScriptableObject
{
   public enum THREAT { None, Low, Moderate, High };
   
    [SerializeField]
    private string plantName;
    [SerializeField]
    private THREAT threatLevel;
    [SerializeField]
    private Texture plantImg;

    public string Name { get { return plantName; } }
    public THREAT Threat { get { return threatLevel; } }
    public Texture Img { get { return plantImg; } }
}
