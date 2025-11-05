using UnityEngine;
using UnityEngine.AI;

public class AgentInteraction : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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
        if (other.CompareTag("Player") && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    private System.Collections.IEnumerator AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true;

        // Play attack animation
        animator.SetTrigger("Attack");

        // Deal damage to the player
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
        }

        // Wait for animation to finish
        yield return new WaitForSeconds(1.1f);

        agent.isStopped = false;
        isAttacking = false;
    }
}
