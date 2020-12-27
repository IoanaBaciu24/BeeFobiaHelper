using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handMovement : MonoBehaviour {
	public bool goUp=true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (goUp)
		{
			transform.Rotate(Vector3.right, Time.deltaTime * 45);
		}

		else
		{
			transform.Rotate(Vector3.left, Time.deltaTime * 45f);

		}

		if (transform.rotation.x >= 0.25f && goUp)
		{
			goUp = false;
			return;
		}
		if (transform.rotation.x <= -0.25f && !goUp)
		{
			goUp = true;
			return;
		}
	}
}
