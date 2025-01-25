using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
	[SerializeField] private float spritspeed = 100f;
    [SerializeField] private float rotatespeed = 8f;
	[SerializeField] private float jumpForce = 5f;
	[SerializeField] private float maxAngle = 60;
	[SerializeField] private Transform holdPoint;

    private bool isWalking;
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
		rb = GetComponent<Rigidbody>();
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

		if(Input.GetKey(KeyCode.LeftShift)){speed = spritspeed;} else{speed = movespeed;}

        Vector3 moveDir = (new Vector3(transform.forward.x, 0f, transform.forward.z) * inputVector.y) + (transform.right * inputVector.x);

        transform.position += moveDir * speed * Time.deltaTime;
		transform.Rotate(0f, mouseInput.x*rotatespeed, 0f);

		float newRotation = Mathf.Clamp(rotX + mouseInput.y * rotatespeed, -maxAngle, maxAngle);
		Head.transform.localRotation = Quaternion.Euler(newRotation, 0f, 0f);

		rotX = newRotation;

        isWalking = moveDir != Vector3.zero;

		if(Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
			isGround = false;
		}
    }
    public bool IsWalking()
    {
        return isWalking;
    }

	private void OnCollisionEnter(Collision collision)
	{
		switch(collision.gameObject.tag)
		{
			case "Ground":
				isGround = true;
				break;

			default:
				break;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		//
	}

	public Transform GetHoldPoint()
	{
		return holdPoint;
	}
}
