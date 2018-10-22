using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour {
    [SerializeField] GameObject rucksack;
    // Use this for initialization
    private void trigger()
    {
        Debug.Log("Im here");
        if(rucksack.activeInHierarchy == false)
        {
            rucksack.SetActive(true);
        }
        else
        {
            rucksack.SetActive(false);
        }
    }


}
