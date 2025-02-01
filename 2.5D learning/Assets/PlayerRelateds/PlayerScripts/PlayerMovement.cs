using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CharacterController characterController;
    private float playerSpeed = 5f;
    [SerializeField] private PlayerAim playerAim;
    public bool IsAiming { get; private set; }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 input = inputManager.movementActions.Move.ReadValue<Vector2>();
        Vector3 inputDirection = new Vector3(input.x, 0, input.y);

        // Get camera direction and flatten out the Y-axis (so we don't rotate vertically)
        Vector3 cameraForward = playerAim.mainCamera.transform.forward;
        Vector3 cameraRight = playerAim.mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the desired movement direction based on camera orientation
        Vector3 moveDirection = cameraRight * inputDirection.x + cameraForward * inputDirection.z;

        // Move the player
        characterController.Move(moveDirection * playerSpeed * Time.deltaTime);

        // Rotate the player to face the direction of movement (when not aiming)
        if (moveDirection.magnitude > 0.1f && !IsAiming)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, playerAim.rotationSpeed * Time.deltaTime);
        }

        // Optionally, handle aiming state if required
        if (IsAiming)
        {
            
        }
    }

    public void SetAimingState(bool isAiming)
    {
        IsAiming = isAiming; // Update aiming state for movement
    }
}
