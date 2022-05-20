using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject eggPrefab;
    //public GameObject aptechkaPrefab;
    public GameObject[] spawnPrefabs;
    public Terrain terrain;
    TerrainData terrainData;
    public Transform player;
    //public Event eggDropEvent;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawner Start");

        terrainData = terrain.terrainData;
        //InvokeRepeating("CreateEgg", 1, 0.1f);
        //         CreateEgg();
        //         CreateEgg();
        //         CreateAptechka();
        //         CreateAptechka();

        CreateObj();
        CreateObj();
        CreateObj();
        CreateObj();
    }

    void CreateObj()
    {
        Debug.Log("Spawner CreateEgg");
        var x = (int)Random.Range(player.position.x, terrainData.size.x / 2.0f);
        var z = (int)Random.Range(player.position.z, terrainData.size.z / 2.0f);
        //var pos = new Vector3(x, 0, z);
        var pos = player.position;
        pos.y = terrain.SampleHeight(pos) + 10;
        foreach (GameObject prefab in spawnPrefabs)
        {
            Instantiate(prefab, pos, Quaternion.identity);
        }
        //eggDropEvent.Occurred(egg);
    }

    //     void CreateEgg()
    //     {
    //         Debug.Log("Spawner CreateEgg");
    //         var x = (int)Random.Range(player.position.x, terrainData.size.x / 2.0f);
    //         var z = (int)Random.Range(player.position.z, terrainData.size.z / 2.0f);
    //         //var pos = new Vector3(x, 0, z);
    //         var pos = player.position;
    //         pos.y = terrain.SampleHeight(pos) + 10;
    //         GameObject egg = Instantiate(eggPrefab, pos, Quaternion.identity);
    //         //eggDropEvent.Occurred(egg);
    //     }
    // 
    //     void CreateAptechka()
    //     {
    //         Debug.Log("Spawner CreateAptechka");
    //         var x = (int)Random.Range(player.position.x, terrainData.size.x / 2.0f);
    //         var z = (int)Random.Range(player.position.z, terrainData.size.z / 2.0f);
    //         //var pos = new Vector3(x, 0, z);
    //         var pos = player.position;
    //         pos.y = terrain.SampleHeight(pos) + 10;
    //         GameObject egg = Instantiate(aptechkaPrefab, pos, Quaternion.identity);
    //         //eggDropEvent.Occurred(egg);
    //     }
}
