using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("03b Lose");
    }
}
