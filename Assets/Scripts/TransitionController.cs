using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    private Animator animator;
    static public bool inAnim = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        TransitionIn();
    }

    private void TransitionIn(){
        if (inAnim)
            animator.SetTrigger("In");
    }

    public void TransitionOut(){
        animator.SetTrigger("Out");
    }
}
