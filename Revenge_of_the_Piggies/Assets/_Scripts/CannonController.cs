using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject piggyPlayer; //This is a reference to the player object
    public float strength = 150; //The scalar that defines the strength of the cannon

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get mouse position and direction of the cannon
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        //"new" because we have declared an empty variable and need to create it and reserve RAM for it
        Vector3 mousePositionInWorldCoordinates = Camera.main.ScreenToWorldPoint(mousePosition); //gets coordinates of mouse
        Vector3 direction = mousePositionInWorldCoordinates - transform.position; //directon for cannon rotation

        //get the rotation of the cannon and have it implemented with mouse movement
        float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;
        //alpha is the angle of rotation for the cannon
        //this line returns a radion and we need a degree to input into a quaterion so we use the rad2deg
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha));

        //fire the cannon upon release of the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            piggyPlayer.transform.parent = null;
            piggyPlayer.GetComponent<Rigidbody2D>().gravityScale = 1;
            piggyPlayer.GetComponent<Rigidbody2D>().AddForce(direction * strength);
        }
    }
}
