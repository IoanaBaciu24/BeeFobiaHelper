using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAroundHive : MonoBehaviour
{

	public float CircleRadius = 5;
	public float TurnChance = 0.05f;
	public float MaxRadius = 5;

	public float Mass = 15;
	public float MaxSpeed = 3;
	public float MaxForce = 15;

	private Vector3 velocity;
	private Vector3 wanderForce;
	public Vector3 target;
	public GameObject hive;
	Queue<Vector3> targets = new Queue<Vector3>();

	private void Start()
	{
		velocity = Random.onUnitSphere;
		wanderForce = GetRandomWanderForce();
		hive = GameObject.Find("BB_066_");
		target = new Vector3(hive.transform.position.x, hive.transform.position.y, hive.transform.position.z);
		targets.Enqueue(new Vector3(hive.transform.position.x, hive.transform.position.y + 3f, hive.transform.position.z));
		targets.Enqueue(new Vector3(Random.Range(hive.transform.position.x - 15f, hive.transform.position.x + 15f), Random.Range(6f, 10f), Random.Range(hive.transform.position.z - 15f, hive.transform.position.z + 15f)));
		targets.Enqueue(new Vector3(Random.Range(hive.transform.position.x - 15f, hive.transform.position.x + 15f), Random.Range(6f, 10f), Random.Range(hive.transform.position.z - 15f, hive.transform.position.z + 15f)));
		targets.Enqueue(new Vector3(Random.Range(hive.transform.position.x - 15f, hive.transform.position.x + 15f), Random.Range(6f, 10f), Random.Range(hive.transform.position.z - 15f, hive.transform.position.z + 15f)));
		targets.Enqueue(new Vector3(Random.Range(hive.transform.position.x - 15f, hive.transform.position.x + 15f), Random.Range(6f, 10f), Random.Range(hive.transform.position.z - 15f, hive.transform.position.z + 15f)));
		targets.Enqueue(new Vector3(Random.Range(hive.transform.position.x - 15f, hive.transform.position.x + 15f), Random.Range(6f, 10f), Random.Range(hive.transform.position.z - 15f, hive.transform.position.z + 15f)));

		//print(hive.transform.position.x + ", " + hive.transform.position.y + ", " + hive.transform.position.z);
		//targets.Enqueue(new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));
		//targets.Enqueue(new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));
		//targets.Enqueue(new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));
		//targets.Enqueue(new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));
		var coroutine = WaitAndPrint(2.0f);
		StartCoroutine(coroutine);
	}

	// Update is called once per frame
	void Update()
	{
		var desiredVelocity = GetWanderForce();
		desiredVelocity = desiredVelocity.normalized * MaxSpeed;

		var steeringForce = desiredVelocity - velocity;
		steeringForce = Vector3.ClampMagnitude(steeringForce, MaxForce);
		steeringForce /= Mass;

		velocity = Vector3.ClampMagnitude(velocity + steeringForce, MaxSpeed);
		transform.position += velocity * Time.deltaTime;
		transform.forward = velocity.normalized;

		//Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
		//Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);

		//var rnd = Random.Range(0.0f, 1.0f);



	}


	private Vector3 GetWanderForce()
	{
		if (transform.position.magnitude > MaxRadius)
		{
			var directionToCenter = (target - transform.position).normalized;
			wanderForce = velocity.normalized + directionToCenter;
		}
		else if (Random.value < TurnChance)
		{
			wanderForce = GetRandomWanderForce();
		}

		return wanderForce;
	}

	private Vector3 GetRandomWanderForce()
	{
		var circleCenter = velocity.normalized;
		var randomPoint = Random.insideUnitCircle;

		var displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
		displacement = Quaternion.LookRotation(velocity) * displacement;

		var wanderForce = circleCenter + displacement;
		return wanderForce;
	}


	private IEnumerator WaitAndPrint(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);
			//print("Coroutine ended: " + Time.time + " seconds");
			var d = targets.Dequeue();
			target = d;
			//print("target " + target.x + ", " + target.y + ", " + target.z);
			//print("d " + target.x + ", " + target.y + ", " + target.z);

			targets.Enqueue(target);
		}
	}
}
