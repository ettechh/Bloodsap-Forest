using UnityEngine;
using UnityEngine.AI;

public class AgentInteraction : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking = false;
    private PlayerHealth playerHealth;

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
            agent.SetDestination(target.position);

        // Update walk animation
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
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

        // Play attack animation
        animator.SetTrigger("Attack");
        
        // Wait for animation to finish
        yield return new WaitForSeconds(1.1f);
        
        // Inflict damage to player
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
    }
}
