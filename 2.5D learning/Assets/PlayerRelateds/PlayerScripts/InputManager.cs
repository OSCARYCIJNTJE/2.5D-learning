using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class InputManager : MonoBehaviour
{
    private PlayerInputs inputActions;

    public PlayerInputs.MovementActions movementActions { get; private set; }
    public PlayerInputs.AimingActions aimingActions { get; private set; }
    public PlayerInputs.SprintingActions sprintingActions { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        inputActions = new PlayerInputs();
        movementActions = inputActions.Movement;
        aimingActions = inputActions.Aiming;
        sprintingActions = inputActions.Sprinting;
    }
    private void OnEnable()
    {
        // Enable the input system when the script is enabled
        inputActions.Enable();
    }

    private void OnDisable()
    {
        // Disable the input system when the script is disabled
        inputActions.Disable();
    }
}
