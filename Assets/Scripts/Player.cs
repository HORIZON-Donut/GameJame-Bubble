using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float rotatespeed = 8f;
	[SerializeField] private float maxAngle = 60;

    private bool isWalking;
	private float rotX;
	private GameObject Head;

	void Start()
	{
		Head = this.transform.GetChild(0).gameObject;
	}

    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
		Vector2 mouseInput = new Vector2(0, 0);

		inputVector.y = Input.GetAxisRaw("Vertical");
		inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector = inputVector.normalized;

		mouseInput.x = Input.GetAxisRaw("Mouse X");
		mouseInput.y = -Input.GetAxisRaw("Mouse Y");
		mouseInput = mouseInput.normalized;

        Vector3 moveDir = new Vector3(transform.forward.x, 0f, transform.forward.z) * inputVector.y;

        transform.position += moveDir * movespeed * Time.deltaTime;
		transform.Rotate(0f, mouseInput.x*rotatespeed, 0f);
		Head.transform.Rotate(mouseInput.y*rotatespeed, 0f, 0f);

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
