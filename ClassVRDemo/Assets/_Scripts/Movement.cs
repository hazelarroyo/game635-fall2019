using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //script has teleportation and locomotion in VR

    public Transform centerEye;
    public float speed = 1f;
    public float deadZoneThresh = 0.05f;

    private RaycastHit lastRaycastHit;
    private Transform controllerPosition;




    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude > deadZoneThresh)
        {
            gameObject.transform.position += centerEye.forward * (Time.deltaTime * speed);
        }

        Physics.Raycast(controllerPosition.position, controllerPosition.transform.forward, out lastRaycastHit);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = lastRaycastHit.point;
        }
    }

}
