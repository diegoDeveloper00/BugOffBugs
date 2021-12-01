using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private AbstractBug bug;

    public event Action<int> damaged = delegate { };

    public event Action kill = delegate { };

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        damaged.Invoke(damage);

        if (currentHealth <= 0f)
        {
            kill.Invoke();
        }

    }
        
}
