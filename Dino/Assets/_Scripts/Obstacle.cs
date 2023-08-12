using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject.GetComponent<PlayerMoving>();

        if (obj != null)
        {
            Destroy(gameObject);
            obj.Dead();
        }
    }
}
