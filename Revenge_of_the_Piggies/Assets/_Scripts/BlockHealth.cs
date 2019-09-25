using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour
{
    private int health = 40;
    public ScoreManager scoreManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = health - 10;
        }

    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            scoreManager.UpdateScore(50);
        }

    }

}
