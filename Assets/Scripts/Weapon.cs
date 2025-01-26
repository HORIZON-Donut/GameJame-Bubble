using UnityEngine;

public class Weapon : MonoBehaviour
{
	public WeaponItem weapon;
	public bool isHolding = false;

    private GameObject bullet;  
    private float fireRate = 0.1f;
    private float nextFireTime = 0f; 

	void Start()
	{
   		bullet = weapon.bullet;
		fireRate = weapon.FireRate;

		bullet.GetComponent<Bullet>().weapon = weapon;
	}

    void Update()
    {    
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime && weapon.BulletNumber > 0 && isHolding)
        {        
            Shoot();
            nextFireTime = Time.time + fireRate;

			weapon.BulletNumber--;
        }
    }
   
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
