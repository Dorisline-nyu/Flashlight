using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTriggerBox : MonoBehaviour
{
    [Tooltip("Enemies to activate when the player enters the trigger.")]
    public List<GameObject> enemies;

    private void Start()
    {
        if (enemies == null || enemies.Count == 0)
        {
            Debug.LogWarning($"[{name}] No enemies assigned to trigger!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (GameObject e in enemies)
        {
            if (e.TryGetComponent(out NavMeshAgent agent))
            {
                agent.enabled = true; // Enable movement on trigger
            }

            if (e.TryGetComponent(out Enemy enemy))
            {
                enemy.player = other.transform; // assign player target
            }
        }
    }
}