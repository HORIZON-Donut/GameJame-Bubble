using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int force; // Force to be applied

    private Rigidbody rb; // Reference to the Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
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
