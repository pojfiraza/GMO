﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagScript : MonoBehaviour {
    [SerializeField] GameObject rucksack;
    Image[] componentList;
    public SpriteRenderer[] itemz = new SpriteRenderer[32];
    // Use this for initialization
    private void Awake()
    {
        componentList = rucksack.GetComponentsInChildren<Image>();
    }
    private void trigger()
    {
        if(rucksack.GetComponent<Image>().enabled == false)
        {
            rucksack.GetComponent<Image>().enabled = true;
            for(int x = 0; x<componentList.Length; x++)
            {
                componentList[x].enabled = true;
            }
            for (int y = 0; y < itemz.Length; y++)
            {
                itemz[y].enabled = true;
            }
        }
        else
        {
            rucksack.GetComponent<Image>().enabled = false;
            for (int x = 0; x < componentList.Length; x++)
            {
                componentList[x].enabled = false;
            }
            for (int y = 0; y < itemz.Length; y++)
            {
                itemz[y].enabled = false;
            }
        }
    }


}
