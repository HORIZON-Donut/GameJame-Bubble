using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private WeaponItem weapon;

    private Transform bullet;  
    private float fireRate = 0.1f;
	private int numberOfBullet;

    private float nextFireTime = 0f; 

	void Start()
	{
		bullet = weapon.bullet;
		fireRate = weapon.FireRate;
		numberOfBullet = weapon.BulletNumber;
	}

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
