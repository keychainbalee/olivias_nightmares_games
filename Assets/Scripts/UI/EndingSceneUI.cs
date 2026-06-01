using UnityEngine;

public class EndingSceneUI : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT GAME");

        Application.Quit();
    }
}