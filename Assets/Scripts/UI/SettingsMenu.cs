using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Slider sfxSlider;

    [SerializeField] private Slider sensitivitySlider;

    private PlayerMovement player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();

        // Music
        if (musicSlider != null)
        {
            musicSlider.value = AudioManager.Instance.MusicVolume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        // SFX
        if (sfxSlider != null)
        {
            sfxSlider.value = AudioManager.Instance.SFXVolume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        // Sensitivity (opsional)
        if (sensitivitySlider != null)
        {
            sensitivitySlider.value =
                PlayerPrefs.GetFloat(
                    "LookSensitivity",
                    0.2f);

            sensitivitySlider.onValueChanged.AddListener(SetSensitivity);

            if (player != null)
            {
                player.SetSensitivity(sensitivitySlider.value);
            }
        }
    }

    private void SetMusicVolume(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    private void SetSFXVolume(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }

    private void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat("LookSensitivity", value);

        if (player != null)
        {
            player.SetSensitivity(value);
        }
    }

    public void SaveSettings()
    {
        AudioManager.Instance.SaveVolume();

        PlayerPrefs.Save();
    }
}