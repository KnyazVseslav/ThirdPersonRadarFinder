using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RadarObject
{
    public Image img { get; set; }
    public GameObject owner { get; set; }
}

public class Radar : MonoBehaviour
{
    public Transform playerPos;

    float mapScale = 2.0f;

    public static List<RadarObject> radObjects = new List<RadarObject>();
    //public Image radarObjImg;

    //public Text textOnItemPickedUp;

    public static void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        radObjects.Add(new RadarObject() { owner = o, img = image });
    }

    public static void RemoveRadarObject(GameObject o)
    {
        List<RadarObject> newList = new List<RadarObject>();
        for (int i = 0; i < radObjects.Count; i++)
        {
            if (radObjects[i].owner == o)
            {
                Destroy(radObjects[i].img);
                continue;
            }
            else
                newList.Add(radObjects[i]);
        }

        radObjects.RemoveRange(0, radObjects.Count);
        radObjects.AddRange(newList);
    }

    void DrawRadarDots()
    {
        foreach (RadarObject ro in radObjects)
        {
            Vector3 radarPos = (ro.owner.transform.position - playerPos.position);
            float distToObject = Vector3.Distance(playerPos.position, ro.owner.transform.position) * mapScale;
            float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

            ro.img.transform.SetParent(this.transform);
            RectTransform rt = this.GetComponent<RectTransform>();
            //Debug.Log(rt.pivot);
            ro.img.transform.position = new Vector3(radarPos.x + rt.pivot.x, radarPos.z + rt.pivot.y, 0) + this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawRadarDots();
    }

    public void ItemDroppedEventReaction(GameObject o)
    {
        //RegisterRadarObject(o, radarObjImg);
        RegisterRadarObject(o, o.GetComponent<Item>().img);
        Debug.Log("Radar  ItemDroppedEventReaction");
    }

    public void ItemPickedUpEventReaction(GameObject o)
    {
        //RegisterRadarObject(o, radarObjImg);
        RemoveRadarObject(o);
        Debug.Log("Radar  ItemPickedUpEventReaction");
//         textOnItemPickedUp.gameObject.SetActive(true);
//         StartCoroutine(DisableText());
    }

//     IEnumerator DisableText()
//     {
//         Debug.Log("Radar  DisableText 1");
//         yield return new WaitForSecondsRealtime(2);
//         Debug.Log("Radar  DisableText 2");
//         textOnItemPickedUp.gameObject.SetActive(false);
//         Debug.Log("Radar  DisableText 3");
//     }
}
