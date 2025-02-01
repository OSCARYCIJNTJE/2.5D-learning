using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisibility : MonoBehaviour
{
    public Transform playerTransform;       // The player’s transform
    public CinemachineVirtualCamera vCam;   // Cinemachine Virtual Camera
    public float maxDistance = 10f;         // Max distance to keep the player visible
    public float minDistance = 2f;          // Minimum distance from the camera
    public float visibilityRadius = 5f;     // Radius within which the player will remain visible when hidden
    public LayerMask obstructionLayers;     // Layers that obstruct the view (e.g., walls)

    private CinemachineFramingTransposer framingTransposer; // For camera distance adjustment
    private Vector3 desiredCameraPosition;

    private void Start()
    {
        // Access the Framing Transposer to adjust the camera's position
        framingTransposer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void LateUpdate()
    {
        // Check if the player is behind an obstruction
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, -vCam.transform.forward, out hit, maxDistance, obstructionLayers))
        {
            // If the player is hidden, try to keep them within the visibility radius
            desiredCameraPosition = hit.point + vCam.transform.forward * visibilityRadius;

            // Adjust the camera’s position based on the desired radius
            framingTransposer.m_CameraDistance = Mathf.Clamp(Vector3.Distance(playerTransform.position, desiredCameraPosition), minDistance, maxDistance);
        }
        else
        {
            // If no obstruction is detected, keep the camera at its normal distance
            framingTransposer.m_CameraDistance = Mathf.Clamp(Vector3.Distance(playerTransform.position, vCam.transform.position), minDistance, maxDistance);
        }

        // Smoothly move the camera to the desired position
        vCam.transform.position = Vector3.Lerp(vCam.transform.position, desiredCameraPosition, Time.deltaTime * 10f);
    }
}
