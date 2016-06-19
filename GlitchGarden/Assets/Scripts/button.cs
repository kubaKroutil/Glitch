using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {

    public GameObject defenderPrefab;
    
    public static GameObject selectedDefender;
    private button[] buttonArray;
    private Text textCost;

    // Use this for initialization
    void Start() {
        buttonArray = GameObject.FindObjectsOfType<button>();

        textCost = GetComponentInChildren<Text>();
        textCost.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
        selectedDefender = null;
    }

    // Update is called once per frame
    void Update() {

    }


    void OnMouseDown()
    {
        foreach (button thisbutton in buttonArray)
        {
            thisbutton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;

    }
}
