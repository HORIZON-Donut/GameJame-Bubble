using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	[SerializeField] private List<WeaponItem> WeaponList = new List<WeaponItem>();

	private Transform holdWeapon;
	
	private int total = 0;
	private int weaponIndex = 0;

	void Update()
	{
		weaponIndex += 1;
		total = WeaponList.Count;
		weaponIndex = weaponIndex%total;
		
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	holdWeapon = WeaponList[weaponIndex].Body;

		//	holdWeapon.SetParent(player.transform);
		//	holdWeapon.parent = player.GetHoldPoint();
		//	holdWeapon.localPosition = Vector3.zero;
		//}
	}

	public void ArmWeapon(Player player)
	{
		Debug.Log("Try ro change Weapon");
	}
}

