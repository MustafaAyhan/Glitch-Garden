using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider, diffSlider;
    public LevelManager levelManager;
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
    }

    private void Update()
    {
        musicManager.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(diffSlider.value);
        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
        diffSlider.value = 2f;
    }
}
