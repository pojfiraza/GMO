using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
    Vector2 position = new Vector2(0, 2);
    void Update()
    {
        Debug.DrawRay(position,Vector2.up, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.up);
        if (hit.collider != null)
            hit.transform.SendMessage("HitByRay");

    }
}
