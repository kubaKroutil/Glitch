using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionController : MonoBehaviour {
    public Slider volumeSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;


  
    // Use this for initialization
    void Start() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", volumeSlider.value);

    }
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        levelManager.LoadLevel("1aStart");
    }
    
  

}
