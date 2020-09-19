using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    public Vector2 Position
    {
        get
        {
            return this.transform.position;
        }

        set
        {
            this.transform.position = value;
        }
    }

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
    public virtual string PrefabPath
    {
        get
        {
            return "";
        }

        set
        {
            this.PrefabPath = value;
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
}
