using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealSoil : MonoBehaviour {

    // Use this for initialization
    protected bool PlayerInRange = false    ;
    private SpriteRenderer soilSprite;
    [SerializeField] private Sprite till;



    // Update is called once per frame
    private void Awake()
    {
        soilSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update () {
        if (PlayerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("COw");
            soilSprite.sprite = till;
            soilSprite.transform.position = gameObject.transform.position;
        }
        else if (PlayerInRange == true && Input.GetKeyDown(KeyCode.R))
        {
            GameObject plant= this.gameObject.transform.GetChild(0).gameObject;
            plant.SetActive(true);
            soilSprite.sprite = till;
            soilSprite.transform.position = gameObject.transform.position;
        }
    }
    protected void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Detector"))
        {
            
            soilSprite.color = new Color(.8f, .8f, .8f);
            Debug.Log("C");
            PlayerInRange = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Detector"))
        {
            soilSprite.color = new Color(1f, 1f, 1f);
            Debug.Log("D");
            PlayerInRange = false;
        }
    }
}
