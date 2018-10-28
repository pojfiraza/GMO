using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertSlot : MonoBehaviour {

    public GameObject[] slots = new GameObject[32];
    public int[] count = new int[32];
    [SerializeField] Slider mana;

    // Eat Items of the Plant Variety
    void eat(int location)
    {
        int nutri = slots[location].GetComponent<PlantObject>().stats[0];
        mana.value += nutri;
        count[location] -= 1;
        if(count[location] == 0)slots[location] = null;
        
    }
    // Delete Objects
    void delete(int location)
    {
        slots[location] = null;
    }
    // Equip Tools
    void equip()
    {

    }

}
