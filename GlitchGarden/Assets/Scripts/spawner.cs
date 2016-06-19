using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    public GameObject[] attackersArray;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        foreach (GameObject thisAttacker in attackersArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    bool isTimeToSpawn (GameObject attacker)
    {
        attacker myAttacker = attacker.GetComponent<attacker>();
       // float spawnDelay = myAttacker.seenEverySeconds;       
        //float spawnPerSec = 1 / spawnDelay;
       
        float spawnTreshhold = 1/ myAttacker.seenEverySeconds * Time.deltaTime / 5;

        return (Random.value < spawnTreshhold);
           
    }

    void Spawn (GameObject attacker)
    {
        GameObject myatacker = Instantiate(attacker)as GameObject;
        myatacker.transform.parent = gameObject.transform;
        myatacker.transform.position = transform.position;

    }
}
