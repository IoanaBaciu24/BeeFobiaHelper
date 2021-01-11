using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviourPet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target_for_movement;
    bool isPet;
    bool goUp = true;
    public GameObject rin;
    public GameObject bee;
    Animator animator;
    //bool rotated = false;
    void Start()
    {
        isPet = false;
        animator = rin.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && Vector3.Distance(transform.position, rin.transform.position) < 7f) {

            GetComponent<beeLookAt>().enabled = false;
            GetComponent<BeeMovement>().enabled = false;
            GetComponent<floatTheBee>().enabled = false;
            transform.position = new Vector3(transform.position.x, 3.38f, transform.position.z);
            isPet = true;
        }

        if(!animator.GetBool("isPetting"))
        {
            GetComponent<beeLookAt>().enabled = true;

            GetComponent<BeeMovement>().enabled = true;
            GetComponent<floatTheBee>().enabled = true;

            isPet = false;
            //rotated = false;
        }

        if(isPet)
        {
            //transform.rotation.Set(0.05f, 0.0f, 0.0f, 0.0f);
            
            //if(!rotated)
            //{
            //    transform.Rotate(360.0f, 0.0f, 0.0f);
            //    rotated = true;
            //}
            if (goUp)
            {
                transform.Rotate(Vector3.right, Time.deltaTime * 30f);
            }

            if(!goUp)
            {
                transform.Rotate(Vector3.left, Time.deltaTime * 30f);

            }
            if (transform.rotation.x >= 0.04f && goUp)
            {
                goUp = false;
                return;
            }
            if (transform.rotation.x <= -0.04f && !goUp)
            {
                goUp = true;
                return;
            }
        }


    }
}
