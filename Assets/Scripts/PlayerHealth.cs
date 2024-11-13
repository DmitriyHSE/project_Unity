using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    //public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        /*if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }*/
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        /*if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }*/
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Или можно перейти на экран окончания игры
        // SceneManager.LoadScene("GameOverScene");
    }
}

