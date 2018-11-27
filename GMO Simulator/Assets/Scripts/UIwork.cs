using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIwork : MonoBehaviour {
    [SerializeField]GameObject dayUI;
    [SerializeField] Slider mana;
    TextMeshProUGUI days;
    private int dayCount = 1;
	void Awake () {
        days = dayUI.GetComponent<TextMeshProUGUI>();
	}
    private void Update()
    {
        if(BedScript.isPressed == true)
        {
            dayCount = BedScript.dayC;
            days.SetText("Day {0} ", dayCount);
            mana.value = 100;
            BedScript.isPressed = false;
        }

    }
}
