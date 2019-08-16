using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    public float movementSpeed;

    //if player presses a button - save to a float value
    private void FixedUpdate()
    {
        //get proper buttons from editor 
        float v = Input.GetAxisRaw("Vertical2");
        //moved racket up and down
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}
