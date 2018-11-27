using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScene : MonoBehaviour {
    bool created = false;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        created = true;
        Debug.Log("Awake: " + this.gameObject);
    }
}
	

