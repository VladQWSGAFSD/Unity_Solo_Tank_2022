using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseController : MonoBehaviour
{
    [Header(" Drag and Drop")]
    [SerializeField] protected GameObject BulletSpawnPosition;
    [SerializeField] protected GameObject BulletPrefab;

    [Header("Variables to change")]
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected float bulletSpeed = 3000f;
    [SerializeField] protected int maxHealth = 5;
    [SerializeField] protected int health;
   // [SerializeField] protected int ammo = 5;
    public bool isDead = false;
    //RaycastHit hit;
    //protected float nextFire;
    //public HealthBar healtBar;
    private void Start()
    {
        
        //healtBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {

    }
    public void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            isDead= true;
            //and display something
        }
    }
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        //    healtBar.SetHealth(health);
           Die();
    }
    protected void Fire()
    {        
        GameObject bullet = Instantiate<GameObject>(BulletPrefab, BulletSpawnPosition.transform.position, BulletSpawnPosition.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(BulletSpawnPosition.transform.up * 33f, ForceMode.Impulse);
        
        // bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //it wouldnt work because youre doing it only once,it should be in update so it continuously translates the object forward
        //bullet.transform.Translate(transform.forward * bulletSpeed);
        Destroy(bullet, 2f);
    }
}
