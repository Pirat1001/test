using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        //Use the camera to convert pixel postion to world position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Set player up direction to the relative direction of the mouse
        transform.up = (Vector3)mousePos - transform.position;
    }
}
