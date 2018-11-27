using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider mana;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject goldF;
    [SerializeField] private AudioClip walk;
    private AudioSource clip;
    private Animator anim;
    public float movementMultiplier = 10.0f;
    Vector2 dir;
    Vector3 location;
    RaycastHit2D hit;
    public int gold = 50; // gold value
    int cgold = 50;
    GameObject s = null; // Game Object Store for Soil
    // Update is called once per frame
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        clip = gameObject.GetComponent<AudioSource>();
        s = null;
    }
    void Update()
    {
        if (gold != cgold)
        {
            goldF.GetComponent<Text>().text = gold.ToString();
        }
        if (pausePanel.activeInHierarchy)
        {

        }


        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (!clip.isPlaying)clip.Play();
            anim.SetBool("MoveL", true);
            anim.SetInteger("Location", 4);
            location = (transform.position + new Vector3(-1f, -.2f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(-0.3f, 0f), .3f);
            dir = Vector2.left;
            transform.Translate(Vector2.left * movementMultiplier * Time.deltaTime);

        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            if (!clip.isPlaying) clip.Play();
            anim.SetBool("MoveB", true);
            anim.SetInteger("Location", 3);
            location = (transform.position + new Vector3(0f, 1f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(0f, .3f), .3f);
            dir = Vector2.up;
            transform.Translate(Vector2.up * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!clip.isPlaying) clip.Play();
            anim.SetBool("MoveR", true);
            anim.SetInteger("Location", 2);
            location = (transform.position + new Vector3(1f, -.2f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(0.3f, 0f), .3f);
            dir = Vector2.right;
            transform.Translate(Vector2.right * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!clip.isPlaying) clip.Play();
            anim.SetBool("MoveF", true);
            anim.SetInteger("Location", 1);
            location = (transform.position + new Vector3(0f, -1f, 0f));
            hit = Physics2D.Raycast(location, new Vector2(0f, -.3f), .3f);
            dir = Vector2.down;
            transform.Translate(Vector2.down * movementMultiplier * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("MoveF", false);
            anim.SetBool("MoveB", false);
            anim.SetBool("MoveL", false);
            anim.SetBool("MoveR", false);
            clip.Stop();
        }

        if (hit.collider != null && (hit.collider.tag == "Soil" || hit.collider.tag == "Trunks"))
        {
            if (s != null && s != hit.collider.gameObject)//Exit Tag
            {
                s.SendMessage("NotHit");
            }
            else hit.transform.SendMessage("HitByRay");
            s = hit.transform.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                s.SendMessage("PressedE");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                s.SendMessage("PressedR");
            }

        }
        else if(s != null)
        {
            s.SendMessage("NotHit");
            s = null;
        }


        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
        {
            movementMultiplier = 2.00f;
            if (hit == true && hit.transform.tag == "Soil") mana.value -= 3;
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.R))
        {
            movementMultiplier = 10.00f;

        }
    }
}
