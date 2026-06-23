using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntro : MonoBehaviour
{
    [System.Serializable]
    public class TutorialData
    {
        [TextArea(3, 5)]
        public string tutorialText;

        public Sprite tutorialImage;

        public bool showImage;
    }

    [Header("Night Panel")]
    [SerializeField] private CanvasGroup nightPanel;
    [SerializeField] private CanvasGroup nightTextGroup;

    [SerializeField] private TMP_Text nightTitle;

    [SerializeField] private string nightName = "MALAM 1";

    [SerializeField] private float displayTime = 2f;
    [SerializeField] private float fadeDuration = 1.5f;

    [Header("Typewriter")]
    [SerializeField] private float typingSpeed = 0.15f;

    [SerializeField] private AudioSource typingAudio;

    [Header("Tutorial")]
    [SerializeField] private bool showTutorial = true;

    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private TMP_Text tutorialText;

    [SerializeField] private Image tutorialImage;

    [Header("Tutorial Data")]
    [SerializeField] private TutorialData[] tutorials;

    private int tutorialIndex = 0;

    private void Start()
    {
        Time.timeScale = 0f;

        tutorialPanel.SetActive(false);

        StartCoroutine(IntroSequence());
    }

    private IEnumerator IntroSequence()
    {
        //--------------------------------
        // RESET
        //--------------------------------

        nightPanel.alpha = 1f;
        nightTextGroup.alpha = 1f;

        nightTitle.text = "";

        //--------------------------------
        // TYPEWRITER EFFECT
        //--------------------------------

        yield return StartCoroutine(TypeNightText());

        //--------------------------------
        // TAHAN SEBENTAR
        //--------------------------------

        yield return new WaitForSecondsRealtime(displayTime);

        //--------------------------------
        // FADE OUT TEXT
        //--------------------------------

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            nightTextGroup.alpha =
                Mathf.Lerp(
                    1f,
                    0f,
                    timer / fadeDuration);

            yield return null;
        }

        //--------------------------------
        // FADE OUT PANEL
        //--------------------------------

        timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            nightPanel.alpha =
                Mathf.Lerp(
                    1f,
                    0f,
                    timer / fadeDuration);

            yield return null;
        }

        nightPanel.gameObject.SetActive(false);

        //--------------------------------
        // TUTORIAL
        //--------------------------------

        if (showTutorial &&
            tutorials != null &&
            tutorials.Length > 0)
        {
            ShowTutorial();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private IEnumerator TypeNightText()
    {
        foreach (char letter in nightName)
        {
            nightTitle.text += letter;

            if (typingAudio != null &&
                typingAudio.clip != null)
            {
                typingAudio.PlayOneShot(
                    typingAudio.clip);
            }

            yield return new WaitForSecondsRealtime(
                typingSpeed);
        }
    }

    private void ShowTutorial()
    {
        tutorialPanel.SetActive(true);

        TutorialData data =
            tutorials[tutorialIndex];

        tutorialText.text =
            data.tutorialText;

        if (data.showImage &&
            data.tutorialImage != null)
        {
            tutorialImage.gameObject.SetActive(true);

            tutorialImage.sprite =
                data.tutorialImage;
        }
        else
        {
            tutorialImage.gameObject.SetActive(false);
        }
    }

    public void NextTutorial()
    {
        tutorialIndex++;

        if (tutorialIndex >= tutorials.Length)
        {
            tutorialPanel.SetActive(false);

            Time.timeScale = 1f;

            return;
        }

        ShowTutorial();
    }
}