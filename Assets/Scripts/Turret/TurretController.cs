using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : BaseController
{
    #region Variables
    [Header(" Drag and Drop")]
    Transform target;
    [SerializeField] Transform turretHead;
    float distance;
    [Header("Variables to change")]
    [SerializeField] float range = 15f;
    [SerializeField] float rotationSpeed = 3f;
    float nextFire;
    RaycastHit hit;

    #endregion

    #region Main
    void Start()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Tank").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AutomaticFire();
    }

    #endregion

    #region Custom Methods
    void AutomaticFire()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance <= range)
        {
            //SmoothOut the rotation
            Vector3 lookDirection = target.position - turretHead.position;
            lookDirection.Normalize();
            turretHead.rotation = Quaternion.Slerp(turretHead.rotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);

            if (Time.time >= nextFire)
            {
                if (Physics.Raycast(BulletSpawnPosition.transform.position, BulletSpawnPosition.transform.up, out hit) && hit.transform.CompareTag("Tank"))
                {
                    Fire();
                    nextFire = Time.time + 1f / fireRate;
                }
            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    #endregion
}
