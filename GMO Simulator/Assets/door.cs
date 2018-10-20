using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private string inside;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("It entered.");
            SceneManager.LoadScene(inside);
        }
        
    }
}
