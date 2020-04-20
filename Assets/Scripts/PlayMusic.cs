using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource intro, full;
    void Start()
    {
        intro.Play();
        full.PlayDelayed(intro.clip.length);
    }
 
}
