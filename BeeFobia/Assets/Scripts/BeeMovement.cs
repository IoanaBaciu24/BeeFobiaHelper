using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject target_for_movement;
    public bool moving;
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, target.position)) > 10f && !moving)
        {
            Move();
            moving = true;
        }
        if (moving && transform.position.x != target_for_movement.transform.position.x && transform.position.z != target_for_movement.transform.position.z)
            Move();

        if (moving && transform.position.x == target_for_movement.transform.position.x && transform.position.z == target_for_movement.transform.position.z)
        {
            moving = false;
            //transform.rotation = Quaternion.LookRotation(target.position, Vector3.up);
        }
    }
    void Move()
    {
        var new_vec = new Vector3(target_for_movement.transform.position.x, transform.position.y, target_for_movement.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, new_vec, 0.29f);
    }
}
