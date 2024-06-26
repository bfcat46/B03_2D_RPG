using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 1.0f;
    public float attackCooldown = 2.0f;

    private Transform player;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player object not found. Ensure the player has the 'Player' tag.");
        }

        lastAttackTime = -attackCooldown;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogError("PlayerHealth component not found on the player.");
        }
    }
}

