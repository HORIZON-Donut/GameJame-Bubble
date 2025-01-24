using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float rotatespeed = 8f;

    private bool isWalking;
	private float rotX;

    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

		inputVector.y = Input.GetAxisRaw("Vertical");
		inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector = inputVector.normalized;

		rotX = Input.GetAxisRaw("Mouse X");

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * movespeed * Time.deltaTime;
		transform.Rotate(0f, rotX*rotatespeed, 0f);

        isWalking = moveDir != Vector3.zero;

        //transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotatespeed);
    }
    public bool IsWalking()
    {
        return isWalking;
    }

	private void OnCollisionEnter(Collision collision)
	{
		//
	}

	private void OnCollisionExit(Collision collision)
	{
		//
	}
}
