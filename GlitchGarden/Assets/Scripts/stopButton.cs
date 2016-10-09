using UnityEngine;
using System.Collections;

public class stopButton : MonoBehaviour {
    private LevelManager levelManager;
    // Use this for initialization
    void Start()
    {
        levelManager = new LevelManager();
    }

    void OnMouseDown()
    {
        levelManager.LoadLevel("1Start");
    }
}
