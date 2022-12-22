using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Tank"))
        {
                            Debug.Log("Test healt."+ collision.gameObject.name);

            if (collision.gameObject.GetComponent<BaseController>() != null)
            {
                collision.gameObject.GetComponent<BaseController>().Damage(damage);
            }
            Destroy(gameObject);
          
        }
        if (collision.gameObject.CompareTag("Turret"))
        {
            if (collision.gameObject.GetComponent<BaseController>() != null)
            {
                collision.gameObject.GetComponent<BaseController>().Damage(damage);
            }  
            Destroy(gameObject);

        }
          
    }
}
