using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attackers>())
        {
            Attackers attackers = collision.gameObject.GetComponent<Attackers>();
            Health health = attackers.GetComponent<Health>();

            if (attackers && health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
