
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 5f;
    public float range = 10f;
    public GameObject playerModel;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(playerModel.transform.position, playerModel.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
