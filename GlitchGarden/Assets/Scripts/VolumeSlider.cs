using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    Slider slider;

	void Start () {

        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

}
