using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = new LevelManager();
    }


    void OnTriggerEnter2D()
    {
        levelManager.LoadLevel("xLose");

    }
}
