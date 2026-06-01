using UnityEngine;
using TMPro;
using System.Collections;

public class DoorUI : MonoBehaviour
{
    public static DoorUI Instance;

    [SerializeField] private GameObject lockedText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowLockedMessage()
    {
        StopAllCoroutines();

        StartCoroutine(ShowMessageRoutine());
    }

    private IEnumerator ShowMessageRoutine()
    {
        lockedText.SetActive(true);

        yield return new WaitForSeconds(2f);

        lockedText.SetActive(false);
    }
}