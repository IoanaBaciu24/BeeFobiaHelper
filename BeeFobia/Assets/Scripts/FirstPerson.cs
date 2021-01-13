using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
	public Rigidbody Rigid;
	float MouseSensitivity = 4f;
	public float MoveSpeed = 0.4f;
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
		bool forward = isMoving();
		bool isWalking = animator.GetBool("isWalking");
		//animation trggers movement
		if (!isWalking && forward)
			animator.SetBool("isWalking", true);
		if (isWalking && !forward)
			animator.SetBool("isWalking", false);

		if (!isWalking && forward && animator.GetBool("isPetting"))
			animator.SetBool("isPetting", false);

		//actual movement + rotations
		Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
		Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
		if (Input.GetKeyDown("space"))
			Rigid.AddForce(transform.up * JumpForce);
	}


	bool isMoving()
    {
		return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetAxis("Mouse X") != 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "plate")
        {
            Rigid.velocity = Vector3.zero;
        }
    }

}
