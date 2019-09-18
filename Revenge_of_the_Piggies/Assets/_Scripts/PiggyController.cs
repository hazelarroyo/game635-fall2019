using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyController : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    Transform cannon;
    public ScoreManager scoreManager;
    const int WAIT_TIME = 3;

    // Start is called before the first frame update
    void Start()
    {   
        cannon = transform.parent;
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreManager.UpdateScore(1);
        Invoke("ResetPiggy", 4);
    }

    void ResetPiggy()
    {
        transform.parent = cannon;
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;


    }
}