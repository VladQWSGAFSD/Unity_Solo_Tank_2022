using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;

public class StaticTurret : BaseController
{
    float staticNextFire;

    void Start()
    {
        health = maxHealth;
    }
    public void DetectAndFire()
    {
        if (Time.time >= staticNextFire)
            {
                Fire();
                staticNextFire = Time.time + 1f / fireRate;     
            }
    }
}
