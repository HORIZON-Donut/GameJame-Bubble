using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	[SerializeField] private List<WeaponItem> WeaponList = new List<WeaponItem>();

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Change Weapon");
		}
	}
}
