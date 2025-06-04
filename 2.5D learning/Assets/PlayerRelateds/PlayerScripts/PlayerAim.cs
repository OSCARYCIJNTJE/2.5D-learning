using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject mainCameraObject;
    [SerializeField] private LayerMask wallsLayer;
    public float rotationSpeed { get; private set; }
    public Camera mainCamera { get; private set; }

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        mainCamera = mainCameraObject.GetComponent<Camera>();
        rotationSpeed = 10f;
    }

    private void Update()
    {
        HandleMouseAim();
    }

    private void HandleMouseAim()
    {
        if (inputManager.aimingActions.Aim.ReadValue<float>() > 0)
        {
            playerMovement.SetAimingState(true);

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, wallsLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

                Vector3 aimDirection = (hit.point - transform.position).normalized;
                aimDirection.y = 0f; 
                Quaternion targetRotation = Quaternion.LookRotation(aimDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            playerMovement.SetAimingState(false);
        }
    }
}
