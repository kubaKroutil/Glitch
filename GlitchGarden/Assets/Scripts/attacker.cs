using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class attacker : MonoBehaviour {

    public float seenEverySeconds;
    protected float currentspeed;
    protected GameObject currentTarget = null;
    protected Animator animator;
    protected gameTimer gameTimer;
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

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }

    }
   

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Defender")
        {
            animator.SetBool("isAttacking", true);
            currentTarget = col.gameObject;
        }
    }

}
