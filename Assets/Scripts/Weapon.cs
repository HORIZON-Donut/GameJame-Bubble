using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private GameObject ShootPoint;
	public WeaponItem weapon;
	public bool isHolding = false;

    private GameObject bullet;
	private Transform shootPoint;
    private float fireRate = 0.1f;
    private float nextFireTime = 0f; 

	void Start()
	{
   		bullet = weapon.bullet;
		fireRate = weapon.FireRate;

		bullet.GetComponent<Bullet>().weapon = weapon;
		shootPoint = ShootPoint.GetComponent<Transform>();
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
        Instantiate(bullet, ShootPoint.transform.position, ShootPoint.transform.rotation);
    }
}
