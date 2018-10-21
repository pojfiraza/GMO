using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Rigidbody2D rigid;
    [SerializeField] GameObject detector;
    [SerializeField] private Slider mana;
    public float movementMultiplier = 10.0f;
    // Use this for initialization
    void Awake () {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var otherPosn = detector.transform.position;
            detector.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(Vector2.left * movementMultiplier * Time.deltaTime);

        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            var otherPosn = detector.transform.position;
            detector.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            transform.Translate(Vector2.up * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            var otherPosn = detector.transform.position;
            detector.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            transform.Translate(Vector2.right * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            var otherPosn = detector.transform.position;
            detector.transform.rotation = Quaternion.Euler(0f, 0f, 90f);    
            transform.Translate(Vector2.down * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            mana.value -= 3;
        }
    }
}
