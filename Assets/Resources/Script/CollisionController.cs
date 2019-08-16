using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    //object of ball movement script
    public BallMovement ballMovement;
    //object of score controller script
    public ScoreController scoreController;

    //bounces ball up or down depending on where it hits on racket
    void BounceFromRacket(Collision2D c)
    {
        //gets ball position
        Vector3 ballPosition = this.transform.position;
        //gets racket position
        Vector3 racketPosition = c.gameObject.transform.position;
        //gets racket height and where it hits on it
        float racketHeight = c.collider.bounds.size.y;
        //ball moves up or down depending on which player hits ball
        float x;
        if(c.gameObject.name == "RacketPlayer1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        //ball goes towards bottom or top
        float y = (ballPosition.y - racketPosition.y) / racketHeight;
        //increases ball speed
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));

    }
        //whenever ball collides with racket, get a collision
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            this.BounceFromRacket(collision);
        }
        //increase score if it hits walls on left or right
        else if (collision.gameObject.name == "WallLeft")
        {
            Debug.Log("Collision with WallLeft");
            this.scoreController.GoalPlayer2();
            //resets ball after score
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight")
        {
            Debug.Log("Collision with WallRight");
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
