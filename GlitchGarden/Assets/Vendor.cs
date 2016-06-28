using UnityEngine;
using System.Collections;

public class Vendor : attacker {
    public GameObject enemyToSpawn;

    private float timeToSpawn = 5f;
    private float currentSpawningTime = 0;

	void Update () {
        
        currentSpawningTime += Time.deltaTime;
        transform.Translate(Vector3.left * currentspeed * Time.deltaTime);
        if (currentSpawningTime > timeToSpawn)
        {
            animator.SetTrigger("spawnTrigger");
            currentSpawningTime = 0;
        }
        Debug.Log("zatim"+ currentSpawningTime);
    }
    void SpawnMinions()
    {      
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    }
}
