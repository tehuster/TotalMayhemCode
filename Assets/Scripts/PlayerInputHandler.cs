using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public InputScriptable playerInput;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        float camDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
        playerInput.mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));
        playerInput.horizontal = Input.GetAxis("Horizontal");
        playerInput.vertical = Input.GetAxis("Vertical");
        playerInput.boost = Input.GetKey(KeyCode.Space);
        playerInput.dodge = Input.GetKey(KeyCode.LeftShift);
    }
}