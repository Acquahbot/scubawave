using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomizer : MonoBehaviour
{
    int rand;
    int rand1;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rand1 = Random.Range(0, 50);
        if(rand1 > 45)
        {
            anim.SetTrigger("specialMacarena");
        }
        else
        {
            rand = Random.Range(0, 3);
            if(rand == 1)
            {
                anim.SetTrigger("Idle1");
            }
            else
            {
                anim.SetTrigger("Idle2");
            }
            
        }
        

        

    }

}
