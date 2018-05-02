using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    public new Camera camera;
    private StarDisplay starDisplay;
    private GameObject projectileParent;

    private void Start()
    {
        projectileParent = GameObject.Find("Defenders");
        starDisplay = FindObjectOfType<StarDisplay>();
        if (!projectileParent)
        {
            projectileParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorlPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defenders>().StarCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
        }
    }

    private void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, roundedPos, zeroRot) as GameObject;

        newDef.transform.parent = projectileParent.transform;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private Vector2 CalculateWorlPointOfMouseClick()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(x, y, distanceFromCamera);
        Vector2 worldPos = camera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
