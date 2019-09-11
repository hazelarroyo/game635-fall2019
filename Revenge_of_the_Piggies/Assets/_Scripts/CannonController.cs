using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody2D piggyPlayerRB; //This is a reference to the player object
    const float STRENGTH = 150; //The scalar that defines the strength of the cannon, "const" = constant (does not allow 
    //vairable to change over time, should be in all caps, right-click to "rename" a variable so that it changes every
    //instance of the variable) 
    public Camera mainCamera;
    Vector3 direction;
    const float MAX_ANGLE = 90;
    const float MIN_ANGLE = 0;


    void Start()
    {

    }

    void Update()
    {
        //get mouse position and direction of the cannon
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z);
        //"new" because we have declared an empty variable and need to create it and reserve RAM for it
        Vector3 mousePositionInWorldCoordinates = mainCamera.ScreenToWorldPoint(mousePosition); //gets coordinates of mouse
        direction = mousePositionInWorldCoordinates - transform.position; //directon for cannon rotation

        //get the rotation of the cannon and have it implemented with mouse movement
        float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;
        //alpha is the angle of rotation for the cannon
        //this line returns a radion and we need a degree to input into a quaterion 
        //so we use the rad2deg

        if (alpha <= MAX_ANGLE && alpha > MIN_ANGLE && direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha));
        }

    }

    void FixedUpdate()
    {
        //fire the cannon upon release of the mouse button
        if (Input.GetButtonUp("Fire 1"))
        {
            piggyPlayerRB.transform.parent = null;
            piggyPlayerRB.gravityScale = 1;
            piggyPlayerRB.AddForce(direction * STRENGTH *piggyPlayerRB.mass);
        }
    }
}
