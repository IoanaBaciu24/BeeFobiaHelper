using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAroundHive : MonoBehaviour
{
    public float CircleRadius = 5;
    public float TurnChance = 0.05f;
    public float MaxRadius = 10;

    public float Mass = 0.001f;
    public float MaxSpeed = 3;
    public float MaxForce = 150;

    private Vector3 velocity;
    private Vector3 wanderForce;
    public GameObject hive; 
    private Vector3 target;

    private void Start()
    {
        velocity = Random.onUnitSphere*0.005f;
        wanderForce = GetRandomWanderForce();
        var prunc = GameObject.Find("prunc");
        target = new Vector3(prunc.transform.position.x, prunc.transform.position.y, prunc.transform.position.z);
    }

    private void Update()
    {
        var desiredVelocity = GetWanderForce();
        desiredVelocity = desiredVelocity.normalized * MaxSpeed;

        var steeringForce = desiredVelocity - velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, MaxForce);
        steeringForce /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steeringForce, MaxSpeed);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);
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
        var randomPoint = Random.insideUnitCircle*10;

        var displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
        displacement = Quaternion.LookRotation(velocity) * displacement;

        var wanderForce = circleCenter + displacement;
        return wanderForce;
    }
}
