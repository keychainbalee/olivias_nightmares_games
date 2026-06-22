using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0f, 1f)]
    public float musicVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            musicVolume =
                PlayerPrefs.GetFloat(
                    "MusicVolume",
                    1f);

            AudioListener.volume = musicVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;

        AudioListener.volume = volume;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(
            "MusicVolume",
            musicVolume);

        PlayerPrefs.Save();
    }
}