using UnityEngine;
using System.Collections;

public class SpawnDefenders : MonoBehaviour {

    public Camera myCamera;
    private GameObject defenderParent;
    private starDisplay starDisplay;


    void Start()
    {
        defenderParent = GameObject.Find("DEFENDERS");
        starDisplay = GameObject.FindObjectOfType<starDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("DEFENDERS");

        }
    }
    void OnMouseDown()
    {
        Vector2 rawPos = CalculatorMouseClicku();
        Vector2 pos = SnapToGrid(rawPos);
        if (button.selectedDefender)
        {
            GameObject defender = button.selectedDefender;
            int defenderCost = defender.GetComponent<Defender>().starCost;
            if (starDisplay.UseStars(defenderCost) == starDisplay.Status.SUCCESS)
            {
                GameObject newDef = Instantiate(defender, pos, Quaternion.identity) as GameObject;
                newDef.transform.parent = defenderParent.transform;
            }
        }
    }

    Vector2 CalculatorMouseClicku ()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceOfCamera = 10f;

        Vector3 weirdo = new Vector3(mouseX, mouseY, distanceOfCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdo);
        return worldPos;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
