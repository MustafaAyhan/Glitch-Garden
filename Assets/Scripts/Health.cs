using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
