using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeLookAt : MonoBehaviour {


	public Transform target;
	public GameObject target_for_movement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		//transform.LookAt(target);
		transform.rotation = Quaternion.LookRotation(target.position, Vector3.up);
		transform.Rotate(0.0f, 90.0f, 0.0f);
        var new_vec = new Vector3(target_for_movement.transform.position.x, transform.position.y, target_for_movement.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, new_vec, 0.07f);
        //transform.position = target.position + new Vector3(3f, transform.position.y - target.position.y, 3f);

    }
}
