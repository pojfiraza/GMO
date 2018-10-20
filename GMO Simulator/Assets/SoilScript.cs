using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilScript : MonoBehaviour {


    protected bool PlayerInRange;
    [SerializeField] private Tilemap soil;
    protected void Update()
    {
        if (PlayerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("YEEEET");
        }
    }

    protected void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Detector"))
        {
            soil.color = new Color(.8f, .8f, .8f);
            Debug.Log("C");
            PlayerInRange = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Detector"))
        {
            soil.color = new Color(1f, 1f, 1f);
            Debug.Log("D");
            PlayerInRange = false;
        }
    }
    
}
