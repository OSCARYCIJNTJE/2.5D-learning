using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class CamSetting : MonoBehaviour
{
    [SerializeField]private ObjectFader objectFader;
    [SerializeField]private GameObject player;

    void Update()
    {
        if (player != null) 
        {
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);

            CheckingHit(ray, player);
            Debug.DrawRay(transform.position, dir, Color.green);
        }
    }

    void CheckingHit(Ray ray, GameObject player)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject != player)
            {
                ObjectFader newObjectFader = hit.collider.gameObject.GetComponent<ObjectFader>();
                if (newObjectFader != null)
                {
                    newObjectFader.SetFade(true); // Tell the object to fade
                }
            }
            else
            {
                if (objectFader != null)
                {
                    objectFader.SetFade(false); // Reset fade when player is visible
                }
            }
        }
    }
}
