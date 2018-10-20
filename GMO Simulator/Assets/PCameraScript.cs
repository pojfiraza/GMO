using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCameraScript : MonoBehaviour {

    public GameObject Player;
    private Vector3 offset;
    public float smoothSpeed = 0.125f;
    private int minx = -14 ;
    private int miny= -7;
    private int maxx = 14;
    private int maxy = 7;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - Player.transform.position;
        Player.SetActive(true);
    }
    // Update is called once per frame

    void LateUpdate()
    {
    
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 desiredPos = Player.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothPos;
        var v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minx, maxx);
        v3.y = Mathf.Clamp(v3.y, miny, maxy);
        transform.position = v3;
    }
}
