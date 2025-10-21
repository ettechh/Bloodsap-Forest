using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound; // optional sound
    public int scoreValue = 1;     // amount to add to score

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touched it
        if (other.CompareTag("Player"))
        {
            // Optional: play sound at collectible’s position
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Add score (optional: if you have a game manager)
            GameManager.Instance.AddScore(scoreValue);

            // Destroy collectible
            Destroy(gameObject);
        }
    }
}
