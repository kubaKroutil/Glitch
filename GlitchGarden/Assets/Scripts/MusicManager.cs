using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    // Use this for initialization

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        if (PlayerPrefs.GetFloat("Volume") == 0)
            audioSource.volume = 0.7f;
    }

    
	void OnLevelWasLoaded (int level)
    {
        AudioClip thislevel = levelMusicChangeArray[level];
        if (thislevel)
        {
            audioSource.clip = thislevel;
            audioSource.loop = true;
            audioSource.Play();
        }
        Debug.Log(PlayerPrefs.GetFloat("Volume"));
    }
    public void ChangeVolume (float volume)
    {
        audioSource.volume = volume;
    }
}
