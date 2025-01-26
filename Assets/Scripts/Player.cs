using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
	[SerializeField] private float spritspeed = 10f;
	[SerializeField] private float midairspeed = 100f;
    [SerializeField] private float rotatespeed = 8f;
	[SerializeField] private float jumpForce = 5f;
	[SerializeField] private float maxAngle = 60;
	[SerializeField] private Transform holdPoint;

	private bool isGround;
	private float rotX = 0f;
	private float speed;

	private GameObject Head;
	private Rigidbody rb;

	private Inventory inventory;

	public float Health = 1000f;	//Player Hp: Take full damage from enemy
	public float Armor = 500f;		//Player Armor: Reduce damage taken
	public float Shield = 250f;		//Player Shield: Complete prevent damage

	public int ArmorTier = 1;		//Player Armor Tier: Higher tier, lower damage taken
	public int ShieldTier = 1;		//Player Shield Tier: Higher tier, lower damage to shield

	void Start()
	{
		Head = this.transform.GetChild(0).gameObject;

		inventory = GetComponent<Inventory>();
		rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
		Walk();
		Rotate();
		Jump();
    }

	private void Walk()
	{
        Vector2 inputVector = new Vector2(0, 0);

		inputVector.y = Input.GetAxisRaw("Vertical");
		inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector = inputVector.normalized;
		
		if(isGround)
		{
			speed = Input.GetKey(KeyCode.LeftShift) ? spritspeed : movespeed;
		}
		else
		{
			speed = Input.GetKey(KeyCode.E) ? midairspeed : movespeed;
		}

        Vector3 moveDir = (new Vector3(transform.forward.x, 0f, transform.forward.z) * inputVector.y) + (transform.right * inputVector.x);

        transform.position += moveDir * speed * Time.deltaTime;
	}

	private void Rotate()
	{
		Vector2 mouseInput = new Vector2(0, 0);

		mouseInput.x = Input.GetAxisRaw("Mouse X");
		mouseInput.y = -Input.GetAxisRaw("Mouse Y");
		mouseInput = mouseInput.normalized;

		transform.Rotate(0f, mouseInput.x*rotatespeed, 0f);

		float newRotation = Mathf.Clamp(rotX + mouseInput.y * rotatespeed, -maxAngle, maxAngle);
		Head.transform.localRotation = Quaternion.Euler(newRotation, 0f, 0f);

		rotX = newRotation;

	}

	private void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
			isGround = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		switch(collision.gameObject.tag)
		{
			case "Ground":
				isGround = true;
				break;

			case "Weapon":
				Weapon newWeapon = collision.gameObject.GetComponent<Weapon>();
				inventory.PickUpWeapon(newWeapon.weapon);

				Destroy(collision.gameObject);
				break;

			case "MedicalSupply":
				SupplyDrop medicalSupply = collision.gameObject.GetComponent<SupplyDrop>();
				Health += medicalSupply.amount;

				Destroy(collision.gameObject);
				break;

			case "ArmorSupply":
				SupplyDrop armorSupply = collision.gameObject.GetComponent<SupplyDrop>();
				addArmorSupply(armorSupply);

				Destroy(collision.gameObject);
				break;

            case "ShieldSupply":
                SupplyDrop shieldSupply = collision.gameObject.GetComponent<SupplyDrop>();
                addShieldSupply(shieldSupply);

                Destroy(collision.gameObject);
                break;

            case "AmmunationSupply":
                SupplyDrop ammunationSupply = collision.gameObject.GetComponent<SupplyDrop>();
                inventory.FillAmmor((int)ammunationSupply.amount);

                Destroy(collision.gameObject);
                break;


            default:
				Debug.Log(collision.gameObject.tag);
				break;
		}
	}

    private void addShieldSupply(SupplyDrop armor)
    {

        if (armor.tier == ShieldTier)
        {
            Shield += armor.amount;
        }
        else if (armor.tier > ShieldTier)
        {
            ShieldTier = armor.tier;
        }
        else if (armor.tier < ShieldTier)
        {
            Shield += armor.amount / ((2 * ShieldTier) - armor.tier);
        }
    }

    private void addArmorSupply(SupplyDrop armor)
	{
		
		if(armor.tier == ArmorTier)
		{
			Armor += armor.amount;
		}
		else if(armor.tier > ArmorTier)
		{
			ArmorTier = armor.tier;
		}
		else if(armor.tier < ArmorTier)
		{
			Armor += armor.amount / ((2 * ArmorTier) - armor.tier);
		}
	}

	public Transform GetHoldPoint()
	{
		return holdPoint;
	}
}
