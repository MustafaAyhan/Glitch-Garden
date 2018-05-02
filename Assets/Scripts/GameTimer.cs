using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 100;
    private Slider slider;
    private AudioSource audio;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winConditionText;

    private void Start()
    {
        slider = GetComponent<Slider>();
        audio = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        winConditionText = GameObject.Find("Level Completed!");

        if (!winConditionText)
        {
            Debug.LogWarning("Please create level completed");
        }

        winConditionText.SetActive(false);
    }

    private void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        bool time = Time.timeSinceLevelLoad >= levelSeconds;
        if (time && !isEndOfLevel && Time.timeSinceLevelLoad != 0)
        {
            audio.Play();
            Invoke("LoadNextLevel", audio.clip.length);
            winConditionText.SetActive(true);
            isEndOfLevel = true;
        }
    }

    private void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
