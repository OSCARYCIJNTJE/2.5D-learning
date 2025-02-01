using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class CamSetting : MonoBehaviour
{
    private ObjectFader objectFader;

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)  // Fix the null check
        {
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);

            CheckingHit(ray, player);
        }
    }

    void CheckingHit(Ray ray, GameObject player)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == player)
            {
                if (objectFader != null)
                {
                    objectFader.doFade = false;
                }
            }
            else
            {
                ObjectFader newObjectFader = hit.collider.gameObject.GetComponent<ObjectFader>();
                if (newObjectFader != null)
                {
                    newObjectFader.doFade = true;
                    objectFader = newObjectFader; // Update reference
                }
            }
        }
    }
}
