using UnityEngine;

public class ExitLevelTrigger : MonoBehaviour
{
    [SerializeField] private LevelComplete levelComplete;

    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished)
            return;

        if (!other.CompareTag("Player"))
            return;

        finished = true;

        levelComplete.CompleteLevel();
    }
}