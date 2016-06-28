using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class attacker : MonoBehaviour, IDealDamage {

    public int health;
    public float seenEverySeconds;
    protected float currentspeed;
    protected Defender currentTarget = null;
    protected Animator animator;
   
    // Use this for initialization
    void Awake()
    {       
        animator = GetComponent<Animator>();
    }

    void Update() {
        transform.Translate(Vector3.left * currentspeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetSpeed(float speed)
    {
        currentspeed = speed;
    }  

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Defender")
        {
            animator.SetBool("isAttacking", true);
            currentTarget = col.gameObject.GetComponent<Defender>();
        }
    }

    public void DealDamage(int damage)
    {
        if (currentTarget)
        {
            currentTarget.health -= damage;
            if (currentTarget.health <= 0)
            {
                Destroy(currentTarget.gameObject);
            }
        }
    }
}