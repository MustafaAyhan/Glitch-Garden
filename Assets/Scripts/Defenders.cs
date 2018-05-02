using UnityEngine;

public class Defenders : MonoBehaviour
{
    public int StarCost = 100;
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
