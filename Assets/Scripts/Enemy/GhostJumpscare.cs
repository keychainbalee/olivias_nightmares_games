using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject jumpscareImage;

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private AudioSource jumpscareAudio;

    private bool triggered;

    public void TriggerJumpscare()
    {
        if (triggered)
        {
            return;
        }

        triggered = true;

        jumpscareImage.SetActive(true);

        if (jumpscareAudio != null)
        {
            jumpscareAudio.Play();
        }

        FreezePlayer();

        Invoke(nameof(ShowGameOver), 2f);
    }

    private void FreezePlayer()
    {
        PlayerFPS player =
            FindFirstObjectByType<PlayerFPS>();

        if (player != null)
        {
            player.enabled = false;
        }
    }

    private void ShowGameOver()
    {
        gameOverUI.SetActive(true);

        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;
    }
}