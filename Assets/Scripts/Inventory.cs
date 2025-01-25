using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	[SerializeField] private List<WeaponItem> WeaponList = new List<WeaponItem>();
	
	private int total = 0;
	private int weaponIndex = 0;

	void Update()
	{
		weaponIndex += 1;
		total = WeaponList.Count;
		weaponIndex = weaponTndex%total;
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//
		}
	}

	void ArmWeapon()
	{
	}
}
