using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedScript : MonoBehaviour {
    public static int dayC = 1;
    public static bool isPressed = false;
    // Default | Hot | Raining | Diseased | Plaque | Drought | Frost
    Color[] weatherStyle = new Color[] { new Color(0f, 0f, 0f, 0f), new Color(0f, 1f, 0f, .25f), new Color(1f, 0f, 0f, .25f) , new Color(0f, 0f, 1f, .25f)};
    [SerializeField] GameObject weatherPanel;
    int temp = 0;
    Image weather;
    GameObject[] Soils;
    [SerializeField] Sprite[] images;
    [SerializeField] GameObject dayPic;
    private void Awake()
    {
        weather = weatherPanel.GetComponent<Image>();
        Soils = GameObject.FindGameObjectsWithTag("Soil");

    }
    private void HitByRay()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            for(int z = 0; z<Soils.Length; z++)
            {
                if (Soils[z].transform.GetChild(0).gameObject.activeSelf == true)
                {
                    PlantObject a =Soils[z].transform.GetChild(0).gameObject.GetComponent<PlantObject>();
                    a.dayz += 1;
                }
                
            }
            int value = Random.Range(0, 90);
            if (value < 50)
            {
                dayPic.GetComponent<Image>().sprite = images[0];
                temp = 0;
            }
            else if(value >= 50 && value < 65)
            {
                dayPic.GetComponent<Image>().sprite = images[1];
                temp = 1;
            }
            else if (value >= 65 && value < 80)
            {
                dayPic.GetComponent<Image>().sprite = images[2];
                temp = 2;
            }
            else if (value >= 80 && value < 90)
            {
                dayPic.GetComponent<Image>().sprite = images[3];
                temp = 3;
            }
            dayC += 1;
            isPressed = true;
            weather.color = weatherStyle[temp];

            
        }
        else
        {
            isPressed = false;
        }
    }
}
