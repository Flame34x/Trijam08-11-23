using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TeamData enemyTeam; // Enum representing different teams
    public int health;
    public float moveSpeed;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.sprite = enemyTeam.enemySprite; // Set the color of the sprite renderer

       transform.Translate(Vector2.down * Time.deltaTime * moveSpeed); // Move the enemy
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.GetComponent<Bullet>().team == enemyTeam) // Check if the bullet is from the same team
            {
                health -= 1; // Reduce health
                Destroy(collision.gameObject); // Destroy the bullet
                if (health <= 0)
                {
                    
                    Destroy(gameObject); // Destroy the enemy
                }

            }
            else
            {
                Destroy(collision.gameObject); // Destroy the bullet
            }
        }
    }
}
