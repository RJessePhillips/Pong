using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    public float movementSpeed;

    //if player presses a button - save to a float value
    private void FixedUpdate()
    {
        //get proper buttons from editor 
        float v = Input.GetAxisRaw("Vertical");
        //moved racket up and down
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}
