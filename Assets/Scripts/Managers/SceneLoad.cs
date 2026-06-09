using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadSceneBaru(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void onApplicationQuit()
    {
        Debug.Log("Keluar dari aplikasi");
        Application.Quit();
    }
}
