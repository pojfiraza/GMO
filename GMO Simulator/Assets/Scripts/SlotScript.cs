using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
    
public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{

    int slotLoc;
    GameObject item;
    GameObject p;
    [SerializeField] GameObject bag;
    [SerializeField] GameObject description;
    [SerializeField] GameObject breedport;

    float diff = 0.3f;
    float delay = 0f;
    bool click = false;


    private void Awake()
    {
        p = transform.parent.gameObject;
        slotLoc = gameObject.transform.GetSiblingIndex();
    }
    // Update is called once per frame
    void Update () {
        if (p.GetComponent<InsertSlot>()!= null && p.GetComponent<InsertSlot>().slots[slotLoc] != null && Input.GetKeyUp(KeyCode.R))
        {
            item = p.GetComponent<InsertSlot>().slots[slotLoc];
            item.transform.SetParent(gameObject.transform);
            item.transform.position = gameObject.transform.position;
            item.GetComponent<SpriteRenderer>().sortingOrder = 6;
            item.GetComponent<SpriteRenderer>().enabled = false;
            item.GetComponent<SpriteRenderer>().sprite = item.GetComponent<PlantObject>().inventoryImage;
            bag.GetComponent<BagScript>().itemz[slotLoc+32] = item.GetComponent<SpriteRenderer>();
            item.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            item.SetActive(true);
            gameObject.GetComponentInChildren<Text>().text = (p.GetComponent<InsertSlot>().count[slotLoc]).ToString();
        }
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left && click == false) // Select Item
        {
            delay = Time.time;
            click = true;
            description.GetComponent<DescriptScript>().itempick = p.GetComponent<InsertSlot>().slots[slotLoc];
            description.SendMessage("ItemPick");

        }
        else{
            
            if(breedport.GetComponent<BreedScript>().father == null)
            {
                breedport.GetComponent<BreedScript>().father = gameObject.transform.GetChild(0).gameObject;
                
                breedport.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
                breedport.GetComponent<BreedScript>().father1 = slotLoc;
            }
            else
            {
                breedport.GetComponent<BreedScript>().mother = gameObject.transform.GetChild(0).gameObject  ;
                breedport.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
                breedport.GetComponent<BreedScript>().mother1 = slotLoc;
            }
            click = false;
        }
        if (eventData.button == PointerEventData.InputButton.Right) // Eat Plants
        {
            p.GetComponent<InsertSlot>().eat(slotLoc);
            gameObject.GetComponentInChildren<Text>().text = (p.GetComponent<InsertSlot>().count[slotLoc]).ToString();
            if ((p.GetComponent<InsertSlot>().count[slotLoc]) == 0)
            {
                gameObject.GetComponentInChildren<Text>().enabled = false;
            }
        }
        Debug.Log(delay + " SDA");
        Debug.Log(Time.time - delay);
        if(Time.time - delay > diff)
        {
            click = false;
        }
       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
