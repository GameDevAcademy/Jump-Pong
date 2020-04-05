using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoint : MonoBehaviour
{
    public Player scorePlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Increase player score
        scorePlayer.Score++;

        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.Reset();
    }
}
