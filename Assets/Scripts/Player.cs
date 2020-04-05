using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.Space;

    public float jumpForce = 2.0f;
    public float minJumpPressedTime = 1.0f;
    public float maxJumpPressedTime = 3.0f;

    public float hitForceMultiplier = 1.1f;

    public int Score = 0;
    
    private Rigidbody2D rigidBody;
    private float jumpPressedTime = 0.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            jumpPressedTime = Time.time;
        }

        if(Input.GetKeyUp(jumpKey))
        {
            float jumpTimer = Time.time - jumpPressedTime;
            jumpTimer = Mathf.Clamp(jumpTimer, minJumpPressedTime, maxJumpPressedTime);

            rigidBody.AddForce(Vector2.up * jumpForce * jumpTimer, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        if(ballRigidbody)
        {
            Vector2 hitNormal = transform.position - collision.transform.position;
            hitNormal.Normalize();

            ballRigidbody.AddForce(hitNormal * hitForceMultiplier);
        }
    }
}
