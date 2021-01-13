using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateFeed : MonoBehaviour
{
    public GameObject shoulder;
    public GameObject elbow;
    public int maxDegreeShoulder;
    public int maxDegreeElbow;

    private bool goToInitial;
    private float angle;
    private bool raiseArm;

    void Start(){
        angle = 0;
        raiseArm = true;
        goToInitial = false;
    }
    
    void Update(){
        float v = 40.0f;
        float dt = Time.deltaTime;
        float degree = v * dt;

        if (Input.GetButton("F key")){
            if (goToInitial)
                goToInitial = false;
            if (raiseArm){
                if (angle + degree > maxDegreeShoulder) {
                    raiseArm = false;
                    angle = 0;
                }
                angle = angle + degree;
                shoulder.transform.Rotate(Vector3.back, degree);
            }
            else
                if (angle + degree < maxDegreeElbow) {
                    angle = angle + degree;
                    elbow.transform.Rotate(Vector3.left, degree);
            }
            else
                goToInitial = true;
        }
        if (goToInitial)
            if (raiseArm)
                if (angle - degree > 0){
                    angle = angle - degree;
                    shoulder.transform.Rotate(Vector3.forward, degree);
                }
                else
                    goToInitial = false;
            else
                if (angle - degree > 0){
                    angle = angle - degree;
                    elbow.transform.Rotate(Vector3.right, degree);
                }
                else {
                    raiseArm = true;
                    angle = maxDegreeShoulder;
                }
    }
}
   
