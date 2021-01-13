using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeToWater : MonoBehaviour
{
    private bool isBeeMoving = false;
    private bool flyOutWindow = false;

    public float up = 10;
    public float right = 23;
    public float down = 3;
    public float speed = 20.0f;
    public float timeToWait = 3;
    public GameObject target;
    
    void Update() {
        float dt = Time.deltaTime;
        float step = speed * dt;
        if (isBeeMoving) 
            MoveToWater(step);

        if (flyOutWindow)
            FlyOutside(step, dt);
    }

    void MoveToWater(float step) {
        if (up > 0){
            up = up - step;
            transform.Translate(Vector3.up * step);
        }
        else{
            if (right > 0){
                right = right - step;
                transform.Translate(Vector3.forward * step);
            }
            else{
                if (down > 0){
                    down = down - step;
                    transform.Translate(Vector3.down * step);
                }
                else{
                    isBeeMoving = false;
                    flyOutWindow = true;
                }
            }
        }
    }

    void FlyOutside(float step, float dt){
        if (timeToWait > 0){
            timeToWait = timeToWait - dt;
            transform.Rotate(Vector3.down, step);
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * 2f);
    }
    void OnCollisionEnter(Collision collision)
    {
        isBeeMoving = true;
    }
}

