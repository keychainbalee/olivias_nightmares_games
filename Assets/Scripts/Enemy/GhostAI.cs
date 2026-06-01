using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [SerializeField] private Transform[] patrolPoints;

    private NavMeshAgent agent;

    [Header("Detection")]
    [SerializeField] private float detectionRange = 8f;

    [SerializeField] private float attackRange = 2f;

    [Header("Movement")]
    [SerializeField] private float patrolSpeed = 2f;

    [SerializeField] private float chaseSpeed = 4.5f;

    private int currentPointIndex;

    private bool isChasing;

    private GhostJumpscare jumpscare;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        jumpscare =
            FindFirstObjectByType<GhostJumpscare>();
    }

    private void Start()
    {
        GoToNextPoint();
    }

    private void Update()
    {
        float distance =
            Vector3.Distance(
                transform.position,
                player.position
            );

        if (distance <= attackRange)
        {
            jumpscare.TriggerJumpscare();

            return;
        }

        if (distance <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (isChasing)
        {
            isChasing = false;

            agent.speed = patrolSpeed;

            GoToNextPoint();
        }

        if (!agent.pathPending &&
            agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    private void ChasePlayer()
    {
        isChasing = true;

        agent.speed = chaseSpeed;

        agent.SetDestination(player.position);
    }

    private void GoToNextPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        agent.SetDestination(
            patrolPoints[currentPointIndex].position
        );

        currentPointIndex++;

        if (currentPointIndex >= patrolPoints.Length)
        {
            currentPointIndex = 0;
        }
    }
}