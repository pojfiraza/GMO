using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject nein;
    [SerializeField] public GameObject descript;
    [SerializeField] GameObject goldCount;
    public GameObject[] shoplist; //Contains all the list of item to buy
    int slotLoc;
    int click = 0;
    int gold = 0;
    
    GameObject p;
    GameObject item;
    public GameObject bag;
    public void PressedR()//Open Menu
    {
        //Turn off the Merchant
    }
    private void Awake()
    {
        
        p = transform.parent.gameObject;
        slotLoc = gameObject.transform.GetSiblingIndex();
        if (p.GetComponent<InsertSlot>() != null && p.GetComponent<InsertSlot>().slots[slotLoc] != null )
        {
            item = Instantiate(p.GetComponent<InsertSlot>().slots[slotLoc]);
            item.transform.SetParent(gameObject.transform);
            item.transform.position = gameObject.transform.position;
            item.GetComponent<SpriteRenderer>().sortingOrder = 6;
            item.GetComponent<SpriteRenderer>().enabled = false;
            item.GetComponent<SpriteRenderer>().sprite = item.GetComponent<PlantObject>().inventoryImage;
            bag.GetComponent<BagScript>().itemz[slotLoc] = item.GetComponent<SpriteRenderer>();
            item.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            item.GetComponent<PlantObject>().enabled = false;
            item.SetActive(true);
            gameObject.GetComponentInChildren<Text>().text = item.GetComponent<PlantObject>().price.ToString();
        }
    }
        
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left)// Select
        {
            
            descript.GetComponent<DescriptScript>().itempick = item;
            descript.GetComponent<DescriptScript>().merchPick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right) // Buy
        {
            gold = System.Int32.Parse(goldCount.GetComponent<Text>().text);
            
            if (gold >= item.GetComponent<PlantObject>().price)
            {
                gold -= item.GetComponent<PlantObject>().price;
                goldCount.GetComponent<Text>().text = gold.ToString();
                int x = 0;
                while(x<nein.GetComponent<InsertSlot>().slots.Length)
                {
                    
                    if(nein.GetComponent<InsertSlot>().slots[x] == null)
                    {
                        
                        GameObject plant = Instantiate(item);
                        plant.GetComponent<PlantObject>().makePlants(plant.GetComponent<PlantObject>().tier, plant.GetComponent<PlantObject>());
                        nein.GetComponent<InsertSlot>().slots[x] = plant;
                        plant.transform.parent = nein.transform.GetChild(x);
                        plant.transform.SetAsFirstSibling();
                        plant.transform.localScale = new Vector3(62f,62f,62f);
                        plant.transform.localPosition = new Vector3(0,0,0);
                        nein.GetComponent<InsertSlot>().count[x] += nein.GetComponent<InsertSlot>().slots[x].GetComponent<PlantObject>().seeds;
                        if(nein.transform.GetChild(x).transform.GetChild(1).GetComponent<Text>().IsActive() == false)
                        {
                            nein.transform.GetChild(x).transform.GetChild(1).GetComponent<Text>().enabled = true;
                        }
                        
                        nein.transform.GetChild(x).transform.GetChild(1).GetComponent<Text>().text = nein.GetComponent<InsertSlot>().count[x].ToString();
                        bag.GetComponent<BagScript>().itemz[slotLoc + 32 + click] = plant.GetComponent<SpriteRenderer>();
                        click++;
                        break;
                    }
                    x++;
                }
            }
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
