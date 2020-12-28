using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
	public Rigidbody Rigid;
	float MouseSensitivity = 1f;
	float MoveSpeed = 0.02f;
	float JumpForce = 2f;
	Animator animator;

	// Use this for initialization
	void Start()
	{
		Rigid = this.GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		bool forward = Input.GetKey(KeyCode.UpArrow);
		bool isWalking = animator.GetBool("isWalking");
		//animation trggers movement
		if (!isWalking && forward)
			animator.SetBool("isWalking", true);
		if (isWalking && !forward)
			animator.SetBool("isWalking", false);

		//actual movement + rotations
		Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
		Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
		if (Input.GetKeyDown("space"))
			Rigid.AddForce(transform.up * JumpForce);
	}

}
