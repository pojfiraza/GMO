using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertSlot : MonoBehaviour {

    public GameObject[] slots = new GameObject[32];
    [SerializeField] GameObject goldCounter;
    public int[] count = new int[32];
    [SerializeField] Slider mana;
    int gold= 0;

    // Eat Items of the Plant Variety

    public void eat(int location)
    {
        if (count[location] == 0) return;
        int nutri = slots[location].GetComponent<PlantObject>().stats[0];
        gold = System.Int32.Parse(goldCounter.GetComponent<Text>().text);
        gold += slots[location].GetComponent<PlantObject>().price/4;
        goldCounter.GetComponent<Text>().text = gold.ToString();
        mana.value += nutri;
        count[location] -= 1;

        if(count[location] == 0) GameObject.Destroy(slots[location]);

    }
    // Delete Objects
    public void delete(int location)
    {
        GameObject.Destroy(slots[location]);
    }
    // Equip Tools
    void equip()
    {

    }

}
