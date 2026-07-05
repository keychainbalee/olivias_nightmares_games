using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private string endingScene = "EndingScene";

    public void CompleteLevel()
    {
        ProgressManager.UnlockNextLevel(currentLevel);

        SceneManager.LoadScene(endingScene);
    }
}