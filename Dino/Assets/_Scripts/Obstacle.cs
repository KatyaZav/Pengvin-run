using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Соприкосновение с " + collision.gameObject);
        Debug.LogWarning("Добавить звук!");

        Destroy(gameObject);
    }
}
