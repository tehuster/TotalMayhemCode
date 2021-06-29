using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputScriptable playerInput;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float camDistance = Vector3.Distance(Vector3.zero, mainCamera.transform.position);
        playerInput.mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));
        playerInput.horizontal = Input.GetAxis("Horizontal");
        playerInput.vertical = Input.GetAxis("Vertical");
        playerInput.boost = Input.GetKey(KeyCode.Space);
        playerInput.dodge = Input.GetKey(KeyCode.LeftShift);
    }
}
