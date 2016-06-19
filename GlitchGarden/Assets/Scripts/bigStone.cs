using UnityEngine;
using System.Collections;

public class bigStone : Defender
{

  
    void OnTriggerStay2D(Collider2D coll)
    {
        attacker attacker = coll.gameObject.GetComponent<attacker>();

        if (attacker)
        {
            animator.SetTrigger("underAttackTrigger");
        }
    }
}
