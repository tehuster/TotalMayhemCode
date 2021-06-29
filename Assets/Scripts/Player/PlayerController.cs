using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputScriptable playerInput;
    public ShipStatsScriptable schipStats;
    public PlayerScriptable playerStats;

    private Vector3 direction;
    private Rigidbody rBody;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RotateTowardsMouse();
        MovePlayer();
        playerStats.currentPosition = transform.position;
    }

    private void MovePlayer()
    {
        Vector3 normalizedRotation = transform.rotation * Vector3.forward;
        rBody.AddForce((normalizedRotation * playerInput.vertical) * schipStats.speed * Time.fixedDeltaTime);
        rBody.AddForce((transform.right * playerInput.horizontal) * schipStats.strafeSpeed * Time.fixedDeltaTime);
    }

    private void RotateTowardsMouse()
    {
        Vector3 targetDirection = (playerInput.mousePosition - transform.position).normalized;
        float singleStep = schipStats.turnSpeed * Time.fixedDeltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, schipStats.turnSpeed, 0.0f);

        newDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }
}
