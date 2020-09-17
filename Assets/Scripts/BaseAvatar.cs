using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    [SerializeField]
    private float health;

    public float Health
    {
        get
        {
            return this.health;
        }

        set
        {
            this.health = value;
        }
    }

    [SerializeField]
    private float maxHealth;

    public float MaxHealth
    {
        get
        {
            return this.maxHealth;
        }

        set
        {
            this.maxHealth = value;
        }
    }

    [SerializeField]
    private float maxSpeeed;
    public float MaxSpeeed
    {
        get
        {
            return this.maxSpeeed;
        }
        set
        {
            this.maxSpeeed = value;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
