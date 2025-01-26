using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int healt = 1;


    private void Update()
    {
        if(healt <= 0)
        {
            Destroy(this.gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            healt -= 1;
        }
        Debug.Log(collision.gameObject.name);
    }


}
