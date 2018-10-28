using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealSoil : MonoBehaviour {

    // Use this for initialization
    protected bool PlayerInRange = false;
    private SpriteRenderer soilSprite;
    [SerializeField] private Sprite till;
    [SerializeField] private Slider mana;
    [SerializeField] private InsertSlot inventory;
    [SerializeField] private GameObject[] plantList = new GameObject[3];
    GameObject target;
    GameObject plant;


    // Update is called once per frame
    private void Awake()
    {
        soilSprite = gameObject.GetComponent<SpriteRenderer>();
        target = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1).gameObject;
    }
    void Update () {

        if (PlayerInRange == true && Input.GetKeyDown(KeyCode.E) && mana.value != 0)
        {
            soilSprite.sprite = till;
            soilSprite.transform.position = gameObject.transform.position;
        }
        else if (PlayerInRange == true && Input.GetKeyDown(KeyCode.R) && mana.value != 0)
        {
            if(this.gameObject.transform.childCount == 1)
            {
                plant = Instantiate(plantList[0], gameObject.transform);
                //plant.GetComponent<PlantObject>().makePlants(3, plant.GetComponent<PlantObject>());
                plant.transform.parent = gameObject.transform;
                plant.transform.SetAsFirstSibling();
                plant.SetActive(true);
            }
            //GameObject plant= this.gameObject.transform.GetChild(0).gameObject;
            Debug.Log(plant.GetComponent<PlantObject>().isRipe);
            if (plant.GetComponent<PlantObject>().isRipe == true)
            {
                for(int c = 0; c < inventory.slots.Length; c++)
                {

                    if(inventory.slots[c] == null)
                    {
                        Debug.Log("SSAS");
                        inventory.slots[c] = Instantiate(plant);
                        inventory.slots[c].SetActive(false);
                        inventory.count[c] += 1;
                        break;
                    }
                    if (plant.GetComponent<PlantObject>().id == inventory.slots[c].GetComponent<PlantObject>().id)
                    {
                        inventory.count[c] += 1;
                        break;
                    }
                }
                Object.Destroy(plant);
                plant.GetComponent<PlantObject>().isRipe = false;
                return;
            }
            plant.SetActive(true);
            soilSprite.transform.position = gameObject.transform.position;
        }
        if (target.activeSelf && Input.anyKey)
        {
            target.SetActive(false);
            soilSprite.color = new Color(1f, 1f, 1f);
            PlayerInRange = false;
        }
    }
    public void HitByRay()
    {
        
        target.SetActive(true);
        soilSprite.color = new Color(.8f, .8f, .8f);
        PlayerInRange = true;
    }
}
