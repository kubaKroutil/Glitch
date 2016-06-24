using UnityEngine;
using System.Collections;

public class shooter : Defender {

    public GameObject projectile;

    private GameObject projectileParent;
    private spawner myLaneSpawner;

    void Awake()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
          
        }
        SetMyLaneSpawner();
    }

    void Update()
    {
        if (isAttackerOnLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    private void Fire()
    {
        GameObject newProjectile = (GameObject)Instantiate(projectile,transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;
    }

    void SetMyLaneSpawner ()
    {
        spawner [] spawnerArray = GameObject.FindObjectsOfType<spawner>();

        foreach (spawner mySpawner in spawnerArray)
        {
            if (mySpawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = mySpawner;
                return;
            }
         }

    }
    bool isAttackerOnLane ()
    {
        if (myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        foreach (Transform child in myLaneSpawner.transform)
        {
            if (child.transform.position.x > transform.position.x)
            {
                return true;
            } 
        }
        return false;
    }
}
