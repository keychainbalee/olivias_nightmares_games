using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [System.Serializable]
    public class LevelData
    {
        [Header("Button")]
        public Button button;

        [Header("Lock Overlay")]
        public GameObject lockPanel;

        [Header("Level")]
        public int levelIndex;

        [Header("Scene")]
        public string sceneName;

        [Header("Locked Message")]
        [TextArea(2, 4)]
        public string lockedMessage;
    }

    [Header("Level List")]
    [SerializeField] private LevelData[] levels;

    [Header("Locked Message Panel")]
    [SerializeField] private GameObject messagePanel;

    [SerializeField] private TMP_Text messageText;

    [Header("Popup Duration")]
    [SerializeField] private float messageDuration = 0.5f;

    private Coroutine messageCoroutine;

    private void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);

        foreach (LevelData level in levels)
        {
            bool unlocked =
                ProgressManager.IsLevelUnlocked(level.levelIndex);

            if (level.lockPanel != null)
            {
                level.lockPanel.SetActive(!unlocked);
            }

            level.button.onClick.RemoveAllListeners();

            if (unlocked)
            {
                string scene = level.sceneName;

                level.button.onClick.AddListener(() =>
                {
                    HideLockedMessage();

                    SceneManager.LoadScene(scene);
                });
            }
            else
            {
                string message = level.lockedMessage;

                level.button.onClick.AddListener(() =>
                {
                    ShowLockedMessage(message);
                });
            }
        }
    }
    public void ShowLockedMessage(string message)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messagePanel.SetActive(true);

        messageText.text = message;

        messageCoroutine =
            StartCoroutine(HideMessageRoutine());
    }
    public void HideLockedMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }
    private IEnumerator HideMessageRoutine()
    {
        yield return new WaitForSeconds(messageDuration);

        HideLockedMessage();
    }
}