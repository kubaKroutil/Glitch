using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {

  

    void OnTriggerEnter2D()
    {
        GameObject.Find("Slider").GetComponent<gameTimer>().LevelLost();
    }
}
