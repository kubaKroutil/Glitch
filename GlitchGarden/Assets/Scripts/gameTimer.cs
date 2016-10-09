using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameTimer : MonoBehaviour {

    public float levelSec = 100;
    public GameObject winLabel;
    public GameObject loseLabel;
    public AudioClip winClip;
    public AudioClip loseClip;

    private Slider slider;
    private bool endOfGame = false;


    void Awake() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        slider.value = Time.timeSinceLevelLoad / levelSec;

        if (Time.timeSinceLevelLoad >= levelSec && !endOfGame) LevelWon();
        if (endOfGame) DestroyAllTaggedObjects();
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");

        foreach (GameObject obj in taggedObjects)
        {
            Destroy(obj);
        }
    }
    void LevelWon()
    {
        AudioSource.PlayClipAtPoint(winClip, transform.position);
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", winClip.length);
        endOfGame = true;
    }

    public void LevelLost()
    {
        AudioSource.PlayClipAtPoint(loseClip, transform.position); 
        loseLabel.SetActive(true);
        Invoke("GoToMenu", loseClip.length);
        endOfGame = true;
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("1Start");
    }
}
