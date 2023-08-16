using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMoving>();

        if (player != null)
        {
            player.Dead(gameObject);
            OnPlayerCollision();
        }
    }

    /// <summary>
    /// What happend on player collision with obstacle
    /// </summary>
    protected virtual void OnPlayerCollision()
    {
       Destroy(gameObject);
    }
}
