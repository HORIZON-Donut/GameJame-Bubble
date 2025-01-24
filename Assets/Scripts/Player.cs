using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float rotatespeed = 8f;
	[SerializeField] public Material selected;
	[SerializeField] public Material unselected;

    private bool isWalking;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
		inputVector.y = Input.GetAxisRaw("Vertical");
		inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * movespeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotatespeed);
        //Debug.Log(inputVector);
    }
    public bool IsWalking()
    {
        return isWalking;
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Counter")
		{
			collision.gameObject.GetComponentInChildren<MeshRenderer>().material = selected;
			Debug.Log(collision.gameObject.name);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.tag == "Counter")
		{
			collision.gameObject.GetComponentInChildren<MeshRenderer>().material = unselected;
		}
	}
}
