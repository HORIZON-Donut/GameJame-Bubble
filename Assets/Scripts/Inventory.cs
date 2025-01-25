using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	[SerializeField] private List<WeaponItem> WeaponList = new List<WeaponItem>();

	private GameObject holdWeapon;
	private Player player;

	private int weaponIndex = 0;
	private Transform holdPoint;

	void Start()
	{
		player = GetComponent<Player>();
		holdPoint = player.GetHoldPoint();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			ArmWeapon();
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
		holdWeapon.transform.SetParent(holdPoint);
		holdWeapon.transform.localPosition = Vector3.zero;
		holdWeapon.transform.localRotation = Quaternion.identity;
	}
}

