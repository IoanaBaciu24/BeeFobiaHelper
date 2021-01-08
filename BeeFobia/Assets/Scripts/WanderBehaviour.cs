using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour
{

    public float CircleRadius = 5;
    public float TurnChance = 0.05f;
    public float MaxRadius = 15;

    public float Mass = 15;
    public float MaxSpeed = 7;
    public float MaxForce = 15;

    private Vector3 velocity;
    private Vector3 wanderForce;
    public Vector3 target;
    public GameObject hive;
    Queue<Vector3> targets = new Queue<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        velocity = Random.onUnitSphere;
        wanderForce = GetRandomWanderForce();

        targets.Enqueue(new Vector3(hive.transform.position.x, hive.transform.position.y, hive.transform.position.z));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 5, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 7, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 5, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 7, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 5, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 7, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 5, Random.Range(400f, 600f))); 
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 7, Random.Range(400f, 600f)));
        targets.Enqueue(new Vector3(Random.Range(300f, 800f), 5, Random.Range(400f, 600f)));
        var coroutine = NextTarget(10.0f);
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

    private void OnCollisionEnter(Collision collision)
    {
       
        wanderForce = GetRandomWanderForce();
    }

    private IEnumerator NextTarget(float waitTime)
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
