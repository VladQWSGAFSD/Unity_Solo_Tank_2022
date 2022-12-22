using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [Header(" Drag and Drop")]
    [SerializeField] protected GameObject BulletSpawnPosition;
    [SerializeField] protected GameObject BulletPrefab;

    [Header("Variables to change")]
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected float bulletSpeed = 3000f;
    [SerializeField] public int maxHealth = 5;
    [SerializeField] public int health;
    //RaycastHit hit;
    //protected float nextFire;
    //public HealthBar healtBar;
    private void Start()
    {
        health = maxHealth;
        //healtBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {

    }
    public void Die()
    {
        Destroy(gameObject);
        //and display something
    }
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        //    healtBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }



    //public void DealDamage(GameObject target)
    //{
    //    var turretc = target.transform.GetComponentInParent<TurretController>();
    //    if (turretc != null)
    //    {
    //        turretc.TakeDamage(damage);
    //    }
    //}
    protected void Fire()
    {
        //GameObject bullet = Instantiate<GameObject>(BulletPrefab, BulletSpawnPosition.transform.position, BulletSpawnPosition.transform.rotation);
        


        GameObject bullet = Instantiate<GameObject>(BulletPrefab, BulletSpawnPosition.transform.position, BulletSpawnPosition.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(BulletSpawnPosition.transform.up * 33f, ForceMode.Impulse);
        // bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //it wouldnt work because youre doing it only once,it should be in update so it continuously translates the object forward
        //bullet.transform.Translate(transform.forward * bulletSpeed);
        Destroy(bullet, 2f);
    }
}
