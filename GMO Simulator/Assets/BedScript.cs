using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedScript : MonoBehaviour {
    public static int dayC = 1;
    public static bool isPressed = false;
    // Default | Hot | Raining | Diseased | Plaque | Drought | Frost
    Color[] weatherStyle = new Color[] { new Color(0f, 0f, 0f, 0f) , new Color(1f, 0.5f, 0.5f, .25f) , new Color(.5f, 0.5f, 1f, .25f) , new Color(.5f, 1f, .5f, .25f) , new Color(0f, 1f, 0f, .25f), new Color(1f, 0f, 0f, .25f) , new Color(0f, 0f, 1f, .25f)};
    [SerializeField] GameObject weatherPanel;
    int temp = 0;
    Image weather;
    private void Awake()
    {
        weather = weatherPanel.GetComponent<Image>();
    }
    private void HitByRay()
    {

        if (Input.GetKeyUp(KeyCode.E))
        {
            int value = Random.Range(0, 105);
            if (value < 40)
            {
                temp = 0;
            }
            else if(value >= 40 && value < 65)
            {
                temp = 1;
            }
            else if (value >= 65 && value < 80)
            {
                temp = 2;
            }
            else if (value >= 80 && value < 90)
            {
                temp = 3;
            }
            else if (value >= 90 && value < 95)
            {
                temp = 4;
            }
            else if (value >= 95 && value < 100)
            {
                temp = 5;
            }
            else if (value >= 100 && value < 105)
            {
                temp = 6;
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
