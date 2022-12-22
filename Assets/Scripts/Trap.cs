using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] StaticTurret turret;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tank")
        {
            turret.DetectAndFire();
        }
    }
}
