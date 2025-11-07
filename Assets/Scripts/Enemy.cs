using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{

    public float health = 100f;
    
    [HideInInspector] public Transform player;
    private NavMeshAgent agent;

    [Header("Rotation Settings")]
    public float rotateSpeed = 5f;

    private ITakeDamage _takeDamageImplementation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Required for 2D NavMeshPlus
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Start disabled so it doesn’t move before activation
        agent.enabled = false;
    }

    void Update()
    {
        if (player == null || !agent.enabled) return;

        // Move toward player
        agent.SetDestination(player.position);

        // Smoothly rotate toward player (2D)
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}