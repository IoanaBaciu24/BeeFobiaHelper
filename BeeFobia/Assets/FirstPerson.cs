using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour {

	public Rigidbody Rigid;
	public float MouseSensitivity = 1f;
	public float MoveSpeed = 1f;
	public float JumpForce = 2f;

	// Use this for initialization
	void Start () {
		Rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
		Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
		if (Input.GetKeyDown("space"))
			Rigid.AddForce(transform.up * JumpForce);
	}

}

