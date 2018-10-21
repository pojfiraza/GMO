using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealSoil : MonoBehaviour {

    // Use this for initialization
    protected bool PlayerInRange = false    ;
    private SpriteRenderer soilSprite;
    [SerializeField] private Sprite till;
    [SerializeField] private Slider mana;
    GameObject target;


    // Update is called once per frame
    private void Awake()
    {
        soilSprite = gameObject.GetComponent<SpriteRenderer>();
        target = this.gameObject.transform.GetChild(1).gameObject;
    }
    void Update () {
        if (PlayerInRange == true && Input.GetKeyDown(KeyCode.E) && mana.value != 0)
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
        if (otherCollider.CompareTag("Detector") && SimpleSoil.isTargetActive == false)
        {
            SimpleSoil.isTargetActive = true;
            if (SimpleSoil.collided > 1)
            {
                target.SetActive(false);
                SimpleSoil.collided -= 1;
            }
            SimpleSoil.collided += 1;
            target.SetActive(true);
            soilSprite.color = new Color(.8f, .8f, .8f);
            Debug.Log("C");
            PlayerInRange = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Detector"))
        {
            SimpleSoil.isTargetActive = false;
            target.SetActive(false  );
            soilSprite.color = new Color(1f, 1f, 1f);
            Debug.Log("D");
            PlayerInRange = false;
            
        }
    }
}
