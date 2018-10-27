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
            Debug.Log("Cow");
            soilSprite.sprite = till;
            soilSprite.transform.position = gameObject.transform.position;
        }
        else if (PlayerInRange == true && Input.GetKeyDown(KeyCode.R) && mana.value != 0)
        {
            if(this.gameObject.transform.childCount == 1)
            {
                Debug.Log("Ca");
                plant = Instantiate(plantList[0], gameObject.transform);
                plant.transform.parent = gameObject.transform;
                plant.transform.SetAsFirstSibling();
                plant.SetActive(true);
            }
            //GameObject plant= this.gameObject.transform.GetChild(0).gameObject;
            Debug.Log(plant.GetComponent<PlantObject>().isRipe);
            if (plant.GetComponent<PlantObject>().isRipe == true)
            {
                Debug.Log(plant.GetComponent<PlantObject>().isRipe);
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
