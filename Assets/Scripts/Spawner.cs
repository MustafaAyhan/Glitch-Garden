using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void Update()
    {
        foreach (GameObject thisAttacker in gameObjects)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    private void Spawn(GameObject gameObject)
    {
        GameObject myAttacker = Instantiate(gameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    private bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attackers attackers = attackerGameObject.GetComponent<Attackers>();
        float spawnDelay = attackers.seenEverySeconds;
        float spawnsPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnsPerSecond)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }
        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold);
    }
}
