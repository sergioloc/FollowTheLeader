using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleButtonController : MonoBehaviour
{
    public bool animate = true;
    private Animator anim;
    void Start()
    {
        if (!animate){
            anim = gameObject.GetComponent<Animator>();
            anim.SetBool("Stop", true);
        }
    }
}
