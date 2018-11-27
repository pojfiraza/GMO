using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptScript : MonoBehaviour
{
    public GameObject itempick;
    [SerializeField] GameObject describe;
    [SerializeField] GameObject nameI;
    [SerializeField] GameObject stat;
    [SerializeField] GameObject buffL;
    public void ItemPick()
    {
        describe.GetComponent<Text>().text = itempick.GetComponent<PlantObject>().description;
        nameI.GetComponent<Text>().text = itempick.GetComponent<PlantObject>().pName;
        stat.transform.GetChild(0).GetComponent<Text>().text = "Nutri:" + itempick.GetComponent<PlantObject>().stats[0].ToString();
        stat.transform.GetChild(1).GetComponent<Text>().text = "Yield:" + itempick.GetComponent<PlantObject>().stats[1].ToString();
        stat.transform.GetChild(2).GetComponent<Text>().text = "DiseR:" + itempick.GetComponent<PlantObject>().stats[2].ToString();
        stat.transform.GetChild(3).GetComponent<Text>().text = "ColdR:" + itempick.GetComponent<PlantObject>().stats[3].ToString();
        stat.transform.GetChild(4).GetComponent<Text>().text = "HeatR:" + itempick.GetComponent<PlantObject>().stats[4].ToString();
        buffL.GetComponent<Text>().text = itempick.GetComponent<PlantObject>().buffs;
    }
    public void merchPick()
    {
        describe.GetComponent<Text>().text = itempick.GetComponent<PlantObject>().description;
        nameI.GetComponent<Text>().text = itempick.GetComponent<PlantObject>().pName;
        buffL.GetComponent<Text>().text = itempick.GetComponent<PlantObject>().buffs;
        stat.transform.GetChild(0).GetComponent<Text>().text = "TIER:" + itempick.GetComponent<PlantObject>().tier.ToString();
        stat.transform.GetChild(1).GetComponent<Text>().text = "";
        stat.transform.GetChild(2).GetComponent<Text>().text = "";
        stat.transform.GetChild(3).GetComponent<Text>().text = "";
        stat.transform.GetChild(4).GetComponent<Text>().text = "";
    }
}
