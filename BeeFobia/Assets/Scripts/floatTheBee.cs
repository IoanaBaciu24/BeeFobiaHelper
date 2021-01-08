using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatTheBee : MonoBehaviour
{
	bool floatup;
	public float howMuch = 0.6f;

	// Use this for initialization
	void Start()
	{
		floatup = false;
	}

	// Update is called once per frame
	void Update()
	{

		if (floatup)
			StartCoroutine(floatingup());
		else if (!floatup)
			StartCoroutine(floatingdown());
	}

	IEnumerator floatingup()
	{
		var new_vec = new Vector3(transform.position.x, transform.position.y + howMuch * Time.deltaTime, transform.position.z);
		transform.position = new_vec;
		yield return new WaitForSeconds(1);
		floatup = false;
	}
	IEnumerator floatingdown()
	{
		var new_vec = new Vector3(transform.position.x, transform.position.y - howMuch * Time.deltaTime, transform.position.z);
		transform.position = new_vec;
		yield return new WaitForSeconds(1);
		floatup = true;
	}
}
