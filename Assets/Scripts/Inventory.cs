using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	[SerializeField] private List<WeaponItem> WeaponList = new List<WeaponItem>();

	private Weapon holdWeapon;
	
	private int total = 0;
	private int weaponIndex = 0;

	void Update()
	{
		weaponIndex += 1;
		total = WeaponList.Count;
		weaponIndex = weaponTndex%total;
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			holdWeapon = WeaponList[weaponIndex]

			holdWeapon.transform.SetParent(this.transform);
			holdWeapon.transform.parent = this.GetHoldPoint();
			holdWeapon.transform.localPosition = Vector3.zeor;
		}
	}

	void ArmWeapon()
	{
	}
}

