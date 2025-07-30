using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerUI playerUI;
    public int maxHealth;
    [SerializeField]private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerUI.LoseHeart(currentHealth + 1);
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void TakeHealing(int healing)
    {
        currentHealth += healing;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        playerUI.WinHealth(currentHealth);
    }
}
