using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float movementSpeed;
    //will count how much the ball speed increases per hit
    public float extraSpeedPerHit;
    //maximum speed variable
    public float maxExtraSpeed;

    //will count racket hits
    int hitCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());

    }

    //reset ball position and velocity depending on who scored
    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }
    //forces ball to wait for new actions so they do not run in parallel
    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        //resets hit counter when ball starts and waits 2 seconds
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        //ball moves left
        if (isStartingPlayer1)
            this.MoveBall(new Vector2(-1, 0));
        else
        {
            //ball moves right
            this.MoveBall(new Vector2(1, 0));
        }
    }

    //ball movement
    public void MoveBall(Vector2 dir)
    {
        //can become a weird value so its normalized
        dir = dir.normalized;
        //increase ball movement when its hit each time
        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;
        //physics aspect of ball which carries ball movement script
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        //influence direction when hit in correct direction
        rigidbody2D.velocity = dir * speed;
    }

    //increase hit couter to make ball go faster
    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
}
