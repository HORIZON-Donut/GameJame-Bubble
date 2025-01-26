using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
	[SerializeField] private float spritspeed = 10f;
    [SerializeField] private float horizontalspeed = 8f;
	[SerializeField] private float verticalspeed = 4f;
	[SerializeField] private float maxAngle = 80f;	
	[SerializeField] private float minAngle = -60f;
	
	[SerializeField] private float Health = 1000f;
	[SerializeField] private float Armor = 500f;
	[SerializeField] private float Shield = 250f;
	[SerializeField] private int Stamina = 500;

	[SerializeField] private float maxHealth = 255;
	[SerializeField] private float maxArmor = 500f;
	[SerializeField] private float maxShield = 500f;
	[SerializeField] private int maxStamina = 1000;
	
	[SerializeField] private int ArmorTier = 1;
	[SerializeField] private int ShieldTier =1;

	[SerializeField] private int staminaDelay = 20;

	[SerializeField] private Transform holdPoint;

	private float rotX = 0f;
	private float speed;
	private int counter = 0;

	private GameObject Head;
	private Rigidbody rb;

	private Inventory inventory;

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
		Stamina = (Stamina > maxStamina) ? maxStamina : Stamina;
		Stamina = (Stamina < 0) ? 0 : Stamina;
    }

	public void TakeDamage(float amount)
	{
		float IncomeDamage = amount;

		if(Shield > 0)
		{
			IncomeDamage = IncomeDamage/(4 * ShieldTier);
			Shield -= IncomeDamage;

			return;
		}

		if(Armor > 0)
		{
			IncomeDamage = IncomeDamage/(2 * ArmorTier);
			Armor -= IncomeDamage;
			IncomeDamage = IncomeDamage/(2 * ArmorTier);
		}

		if(Health > 0)
		{
			Health -= IncomeDamage;
		}
	}

	private void increaseStamina()
	{
		counter++;
		if(counter > staminaDelay)
		{
			counter = 0;
			Stamina++;
		}
	}

	private void Walk()
	{
        Vector2 inputVector = new Vector2(0, 0);

		inputVector.y = Input.GetAxisRaw("Vertical");
		inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector = inputVector.normalized;
		
		if(Input.GetKey(KeyCode.LeftShift) && Stamina > 200)
		{
			speed = spritspeed;
			Stamina -= 2;
		}
		else if(Input.GetKey(KeyCode.LeftShift) && Stamina < 200)
		{
			speed = spritspeed / 2;
			Stamina -= 4;
		}
		else
		{
			if(Stamina > 0){speed = movespeed;}
			else {speed = movespeed / 2;}
			increaseStamina();
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

		transform.Rotate(0f, mouseInput.x*horizontalspeed, 0f);

		float newRotation = Mathf.Clamp(rotX + mouseInput.y * verticalspeed, minAngle, maxAngle);
		Head.transform.localRotation = Quaternion.Euler(newRotation, 0f, 0f);

		rotX = newRotation;

	}

	private void OnCollisionEnter(Collision collision)
	{
		switch(collision.gameObject.tag)
		{
			case "Weapon":
				Weapon newWeapon = collision.gameObject.GetComponent<Weapon>();
				inventory.PickUpWeapon(newWeapon.weapon);

				Destroy(collision.gameObject);
				break;

			case "MedicalSupply":
				SupplyDrop medicalSupply = collision.gameObject.GetComponent<SupplyDrop>();
				if(Health < maxHealth)
				{
					Health += medicalSupply.amount;
				}

				Destroy(collision.gameObject);
				break;

			case "ArmorSupply":
				SupplyDrop armorSupply = collision.gameObject.GetComponent<SupplyDrop>();
				if(Armor < maxArmor)
				{
					addArmorSupply(armorSupply);
				}

				Destroy(collision.gameObject);
				break;

            case "ShieldSupply":
                SupplyDrop shieldSupply = collision.gameObject.GetComponent<SupplyDrop>();
				if(Shield < maxShield)
				{
                	addShieldSupply(shieldSupply);
				}

                Destroy(collision.gameObject);
                break;

            case "AmmunationSupply":
                SupplyDrop ammunationSupply = collision.gameObject.GetComponent<SupplyDrop>();
                if(inventory.FillAmmor((int)ammunationSupply.amount, ammunationSupply.tier))
				{
					Destroy(collision.gameObject);
				}

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

	public float GetHalth()
	{
		return Health;
	}

	public float GetArmor()
	{
		return Armor;
	}

	public float GetShield()
	{
		return Shield;
	}

	public int GetStamina()
	{
		return Stamina;
	}
}
