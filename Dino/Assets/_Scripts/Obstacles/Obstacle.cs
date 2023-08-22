using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            OnPlayerCollision(player);
        }
    }

    /// <summary>
    /// Actions happend on player collision with obstacle
    /// </summary>
    protected virtual void OnPlayerCollision(PlayerController player)
    {
        player.OnDead(gameObject);
        Destroy(gameObject);
    }
}
