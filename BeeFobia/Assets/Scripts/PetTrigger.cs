using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool interact = Input.GetKey("e");
        //animation trggers movement
        if (interact)
            animator.SetBool("isPetting", true);
    }
}
