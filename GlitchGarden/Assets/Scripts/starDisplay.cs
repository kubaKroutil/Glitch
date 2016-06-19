using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class starDisplay : MonoBehaviour {

    private Text myText;
    public int starsCount =100;
    public enum Status {SUCCESS, FAILURE }
    // Use this for initialization
    void Start() {
        
        myText = GetComponent<Text>();
        myText.text = starsCount.ToString();
    }

    public void AddStars(int mount)
    {
        starsCount += mount;
        myText.text = starsCount.ToString();

    }

    public Status UseStars(int mount)
    {
        if (starsCount >= mount)
        {
            starsCount -= mount;
            myText.text = starsCount.ToString();
            return Status.SUCCESS;
        }
       
            return Status.FAILURE;  

    }



}
