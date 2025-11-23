using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public UIManager uiManager;  // drag & drop your UI manager object here

    void Start()
    {
        currentHealth = maxHealth;

        // update UI at start (optional)
        if (uiManager != null)
            uiManager.UpdateDamageOverlay(currentHealth, maxHealth);
    }

    public void TakeDamage()
    {
        currentHealth--;

        // tell UI that health changed
        if (uiManager != null)
            uiManager.UpdateDamageOverlay(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died.");
        SceneManager.LoadScene(2);
    }
}
