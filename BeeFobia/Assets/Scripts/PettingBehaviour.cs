using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettingBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public bool done;
    public GameObject whomstMoves;
    void Start()
    {
        animator = GetComponent<Animator>();
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool isPetting = animator.GetBool("isPetting");

        if (Input.GetKey("e") && !isPetting)
        {
            animator.SetBool("isPetting", true);
            done = false;
        }
        if(done && isPetting)
        {
            animator.SetBool("isPetting", false);
        }
        //fun fun moving the arm for petting 
        if(!done)
        {
            //if(!movingFromAnotherScript)
                //execute movement
            //if(ceva)
            //done = true;//condiotion by a variable
        }
    }
}
