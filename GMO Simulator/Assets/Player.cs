using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private Slider mana;
    [SerializeField] private GameObject pausePanel;
    public float movementMultiplier = 10.0f;
    Vector2 dir;
    Vector3 location;
    RaycastHit2D hit;
	// Update is called once per frame
	void Update () {
        if (pausePanel.activeInHierarchy)
        {
            
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            location = (transform.position + new Vector3(-1f, -.2f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(-0.3f, 0f), .3f);
            dir = Vector2.left;
            transform.Translate(Vector2.left * movementMultiplier * Time.deltaTime);

        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            location = (transform.position + new Vector3(0f, 1f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(0f,.3f),.3f);
            dir = Vector2.up;
            transform.Translate(Vector2.up * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            location = (transform.position + new Vector3(1f, -.2f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(0.3f, 0f),.3f);
            dir = Vector2.right;
            transform.Translate(Vector2.right * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            location = (transform.position + new Vector3(0f, -1f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(0f, -.3f), .3f);
            dir = Vector2.down;
            transform.Translate(Vector2.down * movementMultiplier * Time.deltaTime);
        }
        Debug.DrawRay(location, dir, Color.green);

        if (hit.collider != null && hit.collider.tag != "Player")
        {
            hit.transform.SendMessage("HitByRay");
        }
            
        if (Input.GetKeyDown(KeyCode.E))
        {
            movementMultiplier = 5.00f;
            mana.value -= 3;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            movementMultiplier = 10.00f;

        }
    }
}
