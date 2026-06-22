using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject settingsPanel;

    [Header("Music")]
    [SerializeField] private AudioSource gameplayMusic;

    [SerializeField] private AudioSource pauseMusic;

    private bool isPaused;

    private void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        pauseMusic.Stop();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;

        pausePanel.SetActive(true);

        if (gameplayMusic != null)
        {
            gameplayMusic.Pause();
        }

        if (pauseMusic != null)
        {
            pauseMusic.Play();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        pausePanel.SetActive(false);

        settingsPanel.SetActive(false);

        if (pauseMusic != null)
        {
            pauseMusic.Stop();
        }

        if (gameplayMusic != null)
        {
            gameplayMusic.UnPause();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenu");
    }
}