using UnityEngine;
using UnityEngine.AI;

public class AgentInteraction : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking = false;
    private PlayerHealth playerHealth;
    
    public float attackRange = 2f; // Distance at which enemy attacks
    private float attackCooldown = 0f; // Cooldown timer

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        if (target != null)
        {
            playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth == null)
                Debug.LogWarning("PlayerHealth component not found on target!");
        }
        else
        {
            Debug.LogError("Target not assigned to " + gameObject.name);
        }
    }

    void Update()
    {
        if (target != null && !isAttacking && GameManager.Instance.score > 0)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            
            // If within attack range and not already attacking, attack
            if (distanceToTarget <= attackRange && attackCooldown <= 0f)
            {
                StartCoroutine(AttackPlayer());
            }
            else
            {
                agent.SetDestination(target.position);
            }
        }

        // Update walk animation
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
        
        // Decrease cooldown timer
        if (attackCooldown > 0f)
            attackCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAttacking && playerHealth != null)
        {
            StartCoroutine(AttackPlayer());
        }
        else if (other.CompareTag("Player") && playerHealth == null)
        {
            Debug.LogWarning("PlayerHealth is null when trying to attack!");
        }
    }

    private System.Collections.IEnumerator AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true;

        // Show damage overlay immediately
        if (playerHealth != null)
            playerHealth.ShowDamageUI();

        // Play attack animation
        animator.SetTrigger("Attack");
        
        // Wait for animation to finish
        yield return new WaitForSeconds(1.1f);
        
        // Inflict actual damage to player
        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
            Debug.Log("Player took damage");
        }
        else
        {
            Debug.LogWarning("Cannot deal damage - PlayerHealth is null!");
        }

        agent.isStopped = false;
        isAttacking = false;
        attackCooldown = 2f; // 2 second cooldown between attacks
    }
}
