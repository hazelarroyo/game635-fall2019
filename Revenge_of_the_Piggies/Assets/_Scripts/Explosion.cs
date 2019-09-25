using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PiggyPlayer")
        {
            gameObject.SetActive(false);
        }
    }
}
