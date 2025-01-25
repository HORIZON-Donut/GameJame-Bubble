using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;  
    public float fireRate = 0.1f; 

    private float nextFireTime = 0f; 

   
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

   
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
