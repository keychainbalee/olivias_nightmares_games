using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    [SerializeField] private AudioSource doorSource;

    public void PlayDoorSound()
    {
        if (doorSource == null)
            return;

        // Jika audio masih berjalan, mulai ulang
        doorSource.Stop();

        doorSource.Play();
    }
}