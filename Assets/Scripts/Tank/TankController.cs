using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : BaseController
{
    #region Variables

    [SerializeField] GameObject tank;
    //[SerializeField] float fireRate = 1f;
    [SerializeField] float tankSpeed = 150f;
    //float nextFireTank;
    //RaycastHit hit;
    float horizontalMove;
    float verticalMove;


    #endregion
    

    #region Main
    private void Start()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        //Move();
        MouseFollow();
        TankFire();

        Repair();
    }
    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region Homemade Methods
    private void Move()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            tank.GetComponent<Rigidbody>();
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * tankSpeed;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 4;
            tank.transform.Rotate(0, horizontalMove, 0);
            tank.transform.Translate(0, 0, verticalMove);

        }
    }
    private void MouseFollow()
    {

    }

    private void Repair()
    {
             
    }
    private void TankFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();

        }
    }

    #endregion
}

