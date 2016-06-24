using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    public int starCost;
    public int health;
    protected starDisplay starDisplay;
    protected Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        starDisplay = GameObject.FindObjectOfType<starDisplay>();
    }

	public void AddStars (int pts)
    {
        starDisplay.AddStars(pts);
    }
}
