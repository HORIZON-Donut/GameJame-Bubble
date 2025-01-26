using UnityEngine;

public class Bullet : MonoBehaviour
{
	public WeaponItem weapon;

    private int force; // Force to be applied
	private float damage;
	private int Type;

    private Rigidbody rb; // Reference to the Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
		force = weapon.BulletSpeed;
		damage = weapon.Damage;
		Type = weapon.DamageType;
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody exists before applying force
        if (rb != null)
        {
            // Apply a relative force in the forward direction
            rb.AddRelativeForce(Vector3.forward * force);
        }
        else
        {
            Debug.LogError("Rigidbody component not found on this GameObject!");
        }
    }
	
	public float DamageOnHit()
	{
		return damage;
	}

	public int DamageType()
	{
		return Type;
	}

    private void OnCollisionEnter(Collision collision)
    {
		switch (collision.gameObject.tag)
		{
			case "Ground":
			case "Wall":
				Destroy(this.gameObject);
				break;

			default:
				Debug.Log("Hit stuff");
				break;
		}
    }
}
