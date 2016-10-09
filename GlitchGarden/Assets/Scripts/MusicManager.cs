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
    }


    void OnLevelWasLoaded (int level)
    {
            audioSource.clip = levelMusicChangeArray[level];
            audioSource.loop = true;
            audioSource.Play();
    }

    public void ChangeVolume (float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
