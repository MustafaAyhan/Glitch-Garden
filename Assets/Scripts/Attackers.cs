using UnityEngine;

public class Attackers : MonoBehaviour
{
    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;
    
    private void Start()
    {
        Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;

        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //Called from the animator at the time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject gameObject)
    {
        currentTarget = gameObject;
    }
}
