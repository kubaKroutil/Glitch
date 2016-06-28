using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameTimer : MonoBehaviour {

    public float levelSec = 100;

    private AudioSource audioSource;   
    private Slider slider;
    private bool endOfGame = false;
    private LevelManager levelManager;
    private GameObject winLabel;
	// Use this for initialization
	void Awake () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("YOUWON");
        winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad /levelSec;      

        if (Time.timeSinceLevelLoad >= levelSec && !endOfGame)
        {
            audioSource.Play();
            DestroyAllTaggedObjects();
            winLabel.SetActive(true);
            Invoke("loadNextLvl", audioSource.clip.length);
            endOfGame = true;
        }
	}

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");

        foreach (GameObject obj in taggedObjects)
        {
            Destroy(obj);   
        }
    }

    void loadNextLvl ()
    {
        levelManager.LoadNextLevel();
    }
}
