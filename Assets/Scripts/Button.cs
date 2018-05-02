using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;
    private Button[] buttonArray;
    private Text cost;

    private void Start()
    {
        buttonArray = FindObjectsOfType<Button>();
        cost = GetComponentInChildren<Text>();
        if (!cost)
        {
            Debug.LogWarning(name + " has no cost text component");
        }
        else
        {
            cost.text = defenderPrefab.GetComponent<Defenders>().StarCost.ToString();
        }
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
