using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner mySpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        //Exit if there is no attackers in lane
        if (mySpawner.transform.childCount <= 0)
        {
            return false;
        }
        //If there are attackers, are they ahead?
        foreach (Transform attacker in mySpawner.transform)
        {
            if (attacker.position.x > transform.position.x)
            {
                return true;
            }
        }

        //Attacker in lane, but behind
        return false;
    }

    private void SetMyLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (var spawner in spawners)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                mySpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + "Can't find a spawner in line");

    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
