using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Volume")]
    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 1f;

    [Range(0f, 1f)]
    [SerializeField] private float sfxVolume = 1f;

    public float MusicVolume => musicVolume;
    public float SFXVolume => sfxVolume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            LoadVolume();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        RefreshAudioSources();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshAudioSources();
    }

    private void RefreshAudioSources()
    {
        // MUSIC
        GameObject[] musicObjects =
        GameObject.FindGameObjectsWithTag("Music");

        Debug.Log("Music Found : " + musicObjects.Length);

        foreach (GameObject obj in musicObjects)
        {
            AudioSource source = obj.GetComponent<AudioSource>();

            if (source != null)
            {
                source.volume = musicVolume;

                Debug.Log(obj.name + " -> " + source.volume);
            }
        }


        // SFX
        GameObject[] sfxObjects =
            GameObject.FindGameObjectsWithTag("SFX");

        foreach (GameObject obj in sfxObjects)
        {
            AudioSource source = obj.GetComponent<AudioSource>();

            if (source != null)
            {
                source.volume = sfxVolume;
            }
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;

        RefreshAudioSources();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;

        RefreshAudioSources();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
}