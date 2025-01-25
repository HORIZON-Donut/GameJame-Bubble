using UnityEngine;

public class pistol : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
