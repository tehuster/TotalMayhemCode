using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;


    private float horizontal;
    private float vertical;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        float camDistance = Vector3.Distance(transform.position, cam.transform.position);

        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));

        var targetDirection = (mousePosition - transform.position).normalized;
        var singleStep = turnSpeed * Time.fixedDeltaTime;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed, 0.0f);

        newDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }
}
