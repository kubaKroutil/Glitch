using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {


    public float speed;
    public float damage;

	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {       
        attacker attacker = coll.gameObject.GetComponent<attacker>();
        Health health = coll.gameObject.GetComponent<Health>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
