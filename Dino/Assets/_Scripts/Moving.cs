using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    Spawner spawner;
    Rigidbody2D rb;
    bool isSpawned = false;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        int speed = 2;
        rb.velocity = new Vector2(-speed, 0);

        if (transform.position.x <= -25)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= 0.5 && !isSpawned)
        {
            spawner.CreateLvl();
            isSpawned = true;
        }
    }
}
