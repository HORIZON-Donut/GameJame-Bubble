using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Weapon", menuName = "WeaponSO")]
public class  WeaponSO: ScriptableObject
{
	public string WeapomName;
	public int BulletNumber;
	public float Damage;
}
