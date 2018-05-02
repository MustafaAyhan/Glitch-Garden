using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class Lizard : MonoBehaviour
{
    private Attackers attackers;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();

        if (PlayerPrefsManager.GetDifficulty() == 2)
        {
            attackers.seenEverySeconds = 6;
        }
        else if (PlayerPrefsManager.GetDifficulty() == 3)
        {
            attackers.seenEverySeconds = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (!gameObject.GetComponent<Defenders>())
            return;
        animator.SetBool("isAttacking", true);
        attackers.Attack(gameObject);
    }
}
