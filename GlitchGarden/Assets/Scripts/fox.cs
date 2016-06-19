using UnityEngine;
using System.Collections;



public class fox : attacker {


    public override void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.GetComponent<Stone>())
        {
            animator.SetTrigger("jumpTrigger");

        } else
        {
            base.OnTriggerEnter2D(col);
        }

    }
}
