using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Weapon", menuName = "WeaponItem")]
public class  WeaponItem: ScriptableObject
{
	public string WeapomName;
	public int BulletNumber;
	public int StartBullet;
	public float Damage;
	public float FireRate;

	public int BulletSpeed;

	public GameObject bullet;
	public GameObject Body;
}
