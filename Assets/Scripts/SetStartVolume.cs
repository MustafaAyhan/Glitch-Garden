using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
        }
        else
        {
            Debug.LogWarning("No music manager was found in Start Scene, can't set volume");
        }
    }
}
