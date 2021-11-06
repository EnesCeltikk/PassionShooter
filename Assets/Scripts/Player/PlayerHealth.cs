using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    static PlayerHealth instance;
    public static PlayerHealth Instance { get { return instance; } }
    bool canTakeDamage = true;

    public int maxHealth = 100;
    float currentHealth = 0;
    public SimpleHealthBar healthBar;


    void Awake()
    {
        // If the instance variable is already assigned, then there are multiple player health scripts in the scene. Inform the user.
        if (instance != null)
            Debug.LogError("There are multiple instances of the Player Health script. Assigning the most recent one to Instance.");

        // Assign the instance variable as the Player Health script on this object.
        instance = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // If the health is less than zero...
        if (currentHealth <= 0)
        {
            // Set the current health to zero.
            currentHealth = 0;
            Debug.Log("Dead");
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
}
