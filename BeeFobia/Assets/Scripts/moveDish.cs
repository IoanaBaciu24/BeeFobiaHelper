using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDish : MonoBehaviour
{
    public GameObject plate;
    private bool isMoving;
    public int speed;

    void Start() {
        isMoving = false;
    }

    void Update(){
        if (isMoving)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isMoving = true;
        Debug.Log("inside");
    }
}
