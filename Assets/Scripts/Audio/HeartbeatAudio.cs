using UnityEngine;

public class HeartbeatAudio : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GhostAI[] ghosts;

    [SerializeField] private AudioSource heartbeatSource;

    private void Update()
    {
        if (heartbeatSource == null)
            return;

        bool isAnyGhostChasing = false;

        foreach (GhostAI ghost in ghosts)
        {
            if (ghost != null && ghost.IsChasing)
            {
                isAnyGhostChasing = true;
                break;
            }
        }

        if (isAnyGhostChasing)
        {
            if (!heartbeatSource.isPlaying)
            {
                heartbeatSource.Play();
            }
        }
        else
        {
            if (heartbeatSource.isPlaying)
            {
                heartbeatSource.Stop();
            }
        }
    }
}