using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	[SerializeField] private List<WeaponItem> WeaponList = new List<WeaponItem>();

	private GameObject holdWeapon;
	private Player player;

	private int weaponIndex = -1;
	private Transform holdPoint;

	void Start()
	{
		player = GetComponent<Player>();
		holdPoint = player.GetHoldPoint();

		if(WeaponList[0] != null)
		{
			WeaponList[0].BulletNumber = WeaponList[0].StartBullet;
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			ArmWeapon();
		}
	}

	public void PickUpWeapon(WeaponItem weaponItem)
	{
		weaponItem.BulletNumber = weaponItem.StartBullet;
		WeaponList.Add(weaponItem);
	}

	public void FillAmmor(int amount, int type)
	{
		foreach (var weapon in WeaponList)
		{
			if(weapon.BulletType == type)
			{
				weapon.BulletNumber += amount;
				return;
			}
		}
	}

	public void ArmWeapon()
	{
		weaponIndex += 1;
		weaponIndex = weaponIndex%WeaponList.Count;

		if(holdWeapon != null)
		{
			Destroy(holdWeapon);
		}

		holdWeapon = Instantiate(WeaponList[weaponIndex].Body, holdPoint.position, holdPoint.rotation);
		holdWeapon.GetComponent<Weapon>().isHolding = true;
		holdWeapon.transform.SetParent(holdPoint);
		holdWeapon.transform.localPosition = Vector3.zero;
		holdWeapon.transform.localRotation = Quaternion.identity;
	}
}

