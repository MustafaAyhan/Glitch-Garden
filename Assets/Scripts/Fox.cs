using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Attackers))]
public class Fox : MonoBehaviour
{
    private Attackers attackers;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();

        if (PlayerPrefsManager.GetDifficulty() == 2)
        {
            attackers.seenEverySeconds = 7.5f;
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
        else if (gameObject.GetComponent<Stone>())
        {
            animator.SetTrigger("jump trigger");
        }
        else
        {
            animator.SetBool("isAttacking", true);
            attackers.Attack(gameObject);
        }
    }
}
