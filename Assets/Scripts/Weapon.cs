using UnityEngine;

public class Weapon : MonoBehaviour
{
	public WeaponItem weapon;

    private GameObject bullet;  
    private float fireRate = 0.1f;
    private float nextFireTime = 0f; 

	void Start()
	{
        weapon.BulletNumber = weapon.StartBullet;

		bullet = weapon.bullet;
		fireRate = weapon.FireRate;

		bullet.GetComponent<Bullet>();
		bullet.setWeaponParent(weapon);
	}

    void Update()
    {    
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime && weapon.BulletNumber > 0)
        {        
            Shoot();
            nextFireTime = Time.time + fireRate;

			weapon.BulletNumber--;
        }
    }

	public void TermGraShoon(int number)
	{
		weapon.BulletNumber += number;
		if(weapon.BulletNumber < 0) weapon.BulletNumber = 0;
	}
   
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
