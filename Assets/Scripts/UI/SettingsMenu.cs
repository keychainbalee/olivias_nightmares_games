using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        musicSlider.value =
            PlayerPrefs.GetFloat(
                "MusicVolume",
                1f);
    }

    public void SaveSettings()
    {
        AudioManager.Instance.SetVolume(
            musicSlider.value);

        AudioManager.Instance.SaveVolume();
    }
}