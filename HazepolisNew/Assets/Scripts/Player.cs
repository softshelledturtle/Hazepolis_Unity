using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStat characterStats;

    public int MaxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        characterStats = new CharacterStat(10);

        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
