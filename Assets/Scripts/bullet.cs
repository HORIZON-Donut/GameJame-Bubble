using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private WeaponItem weapon;

    private int force; // Force to be applied
	private float damage;

    private Rigidbody rb; // Reference to the Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
		force = weapon.BulletSpeed;
		damage = weapon.Damege;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag  != "Player")
        {
            // dek Bullet ออกจาก Scene
            Destroy(this.gameObject);
        }
            
    }
}
