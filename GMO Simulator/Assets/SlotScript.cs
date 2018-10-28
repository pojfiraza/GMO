using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour {

    int slotLoc;
    GameObject item;
    GameObject p;
    [SerializeField] GameObject bag;
    private void Awake()
    {
        p = transform.parent.gameObject;
        slotLoc = gameObject.transform.GetSiblingIndex();
    }
    // Update is called once per frame
    void Update () {

        if (p.GetComponent<InsertSlot>().slots[slotLoc] != null && Input.GetKeyUp(KeyCode.R))
        {
            item = p.GetComponent<InsertSlot>().slots[slotLoc];
            item.transform.SetParent(gameObject.transform);
            item.transform.position = gameObject.transform.position;
            item.GetComponent<SpriteRenderer>().sortingOrder = 6;
            item.GetComponent<SpriteRenderer>().enabled = false;
            bag.GetComponent<BagScript>().itemz[slotLoc] = item.GetComponent<SpriteRenderer>();
            item.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            item.SetActive(true);
        }
	}
}
