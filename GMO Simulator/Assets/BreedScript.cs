using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreedScript : MonoBehaviour {

    public GameObject father;
    public int father1;
    public int mother1;
    public GameObject mother;
    [SerializeField] GameObject inventory;
    GameObject baby;

    public void Breed()
    {
        System.Random rand = new System.Random();
        if (father.GetComponent<PlantObject>().pName == mother.GetComponent<PlantObject>().pName)
        {
            father.GetComponent<PlantObject>().buffs = "";
            baby = father;
            PlantObject fathergene = father.GetComponent<PlantObject>();
            PlantObject mothergene = mother.GetComponent<PlantObject>();
            PlantObject babygene = baby.GetComponent<PlantObject>();
            for (int x = 0; x < babygene.stats.Length; x++)
            {
                babygene.stats[x] = ((mothergene.stats[x] + fathergene.stats[x]) / 2) + rand.Next(-2, 3);
            }
            for (int x = 0; x < babygene.dnaSize; x++)
            {
                babygene.dna[0][x] = fathergene.dna[rand.Next(0, 2)][x];
                babygene.dna[1][x] = mothergene.dna[rand.Next(0, 2)][x];
            }
            babygene = babygene.buffList(babygene, babygene.pName);
            Destroy(baby.GetComponent<PlantObject>());
            babygene = baby.AddComponent(typeof(PlantObject)) as PlantObject;
            Destroy(inventory.transform.GetChild(father1).transform.GetChild(0).gameObject);
            inventory.GetComponent<InsertSlot>().slots[father1] = null;
            Destroy(inventory.transform.GetChild(mother1).transform.GetChild(0).gameObject);
            inventory.GetComponent<InsertSlot>().slots[mother1] = null;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
            father = null;
            mother = null;
            
            bool cancel = false;
            for (int y = 0; y < inventory.GetComponent<InsertSlot>().slots.Length; y++)
            {
                if (inventory.GetComponent<InsertSlot>().slots[y] ==null && cancel == false)
                {
                    cancel = true;
                    GameObject plant = Instantiate(baby);
                    plant.GetComponent<PlantObject>().makePlants(plant.GetComponent<PlantObject>().tier, plant.GetComponent<PlantObject>());
                    inventory.GetComponent<InsertSlot>().slots[y] = plant;
                    plant.transform.parent = inventory.transform.GetChild(y);
                    plant.transform.SetAsFirstSibling();
                    plant.transform.localScale = new Vector3(62f, 62f, 62f);
                    plant.transform.localPosition = new Vector3(0, 0, 0);
                    inventory.GetComponent<InsertSlot>().count[y] += inventory.GetComponent<InsertSlot>().slots[y].GetComponent<PlantObject>().seeds;
                    Debug.Log(inventory.transform.GetChild(1).gameObject.transform.GetChild(1).name);

                }
                else
                {
                  
                    if (inventory.transform.GetChild(y).gameObject.transform.GetChild(1).GetComponent<Text>().IsActive() == true)
                    {
                        inventory.transform.GetChild(y).gameObject.transform.GetChild(1).GetComponent<Text>().enabled = false;
                    }
                }
            }
            
        }
    }
}
