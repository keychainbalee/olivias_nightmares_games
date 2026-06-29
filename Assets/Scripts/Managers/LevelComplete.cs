using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [Header("Level Progress")]
    [SerializeField] private int currentLevel = 1;

    [Header("Next Scene")]
    [SerializeField] private string nextScene = "EndingScene";

    public void CompleteLevel()
    {
        ProgressManager.UnlockNextLevel(currentLevel);

        SceneManager.LoadScene(nextScene);
    }
}