using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startForce = 10.0f;
    public float adjustForce = 10.0f;

    private Rigidbody2D rigidBody;

    public void Reset()
    {
        transform.position = Vector2.zero;
        rigidBody.velocity = Vector2.zero;

        Invoke("KickBall", 3.0f);
    }

    private void KickBall()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        rigidBody.AddForce(direction * startForce, ForceMode2D.Impulse);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
        Reset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velAdjust = Vector2.zero;

        float xVel = Mathf.Abs(rigidBody.velocity.x);
        float yVel = Mathf.Abs(rigidBody.velocity.y);

        if (yVel > xVel)
        {
            velAdjust = Vector2.right * Mathf.Sign(rigidBody.velocity.x);
        }
        else
        {
            velAdjust = Random.insideUnitCircle;
        }

        rigidBody.AddForce(velAdjust * adjustForce);
    }
}
