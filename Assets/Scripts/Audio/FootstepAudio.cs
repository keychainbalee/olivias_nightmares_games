using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CharacterController controller;

    [Header("Audio")]
    [SerializeField] private AudioSource footstepSource;

    [Header("Pitch")]
    [SerializeField] private float walkPitch = 1f;
    [SerializeField] private float runPitch = 1.35f;

    private void Update()
    {
        bool shouldPlay =
            controller.isGrounded &&
            playerMovement.IsMoving();

        if (!shouldPlay)
        {
            if (footstepSource.isPlaying)
                footstepSource.Stop();

            return;
        }

        footstepSource.pitch =
            playerMovement.IsRunning()
            ? runPitch
            : walkPitch;

        if (!footstepSource.isPlaying)
        {
            footstepSource.Play();
        }
    }
}