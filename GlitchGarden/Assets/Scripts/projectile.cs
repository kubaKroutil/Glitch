using UnityEngine;
using System.Collections;
using System;

public class projectile : MonoBehaviour,IDealDamage {


    public float speed;
    public int damage;
    private attacker target = null;

	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {       
        attacker attacker = coll.gameObject.GetComponent<attacker>();
        if (attacker)
        {
            target = attacker;
            DealDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public void DealDamage(int damage)
    {
        target.health -= damage;
        if (target.health <= 0)
        {
            Destroy(target.gameObject);
        }
    }
}
