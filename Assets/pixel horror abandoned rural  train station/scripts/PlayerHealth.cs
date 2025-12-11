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

    public void ShowDamageUI()
    {
        // Show damage overlay immediately (before actual damage is applied)
        int predictedHealth = currentHealth - 1;
        if (uiManager != null)
            uiManager.UpdateDamageOverlay(predictedHealth, maxHealth);
    }

    public void Die()
    {
        Debug.Log("Player died.");

        // Unlock and show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Reload the current scene
        SceneManager.LoadScene(2);
    }
}
