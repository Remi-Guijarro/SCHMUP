using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    [SerializeField]
    private float energyNeeded;

    public float EnergyNeeded
    {
        get
        {
            return energyNeeded;
        }

        set
        {
            this.energyNeeded = value;
        }
    }

    public BulletFactory.BulletType Type{
        get;
        
        set;
    }


    [SerializeField]
    private float damage;
   
    public float Damage
    {
        get
        {
            return this.damage;
        }

        set
        {
            this.damage = value;
        }
    }

    [SerializeField]
    private Vector2 speed;

    public Vector2 Speed
    {
        get
        {
            return this.speed;
        }

        set
        {
            this.speed = value;
        }
    }

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
    private float maxSpeed;

    public float MaxSpeed
    {
        get
        {
            return this.maxSpeed;
        }

        set
        {
            this.maxSpeed = value;
        }
    }

    public virtual void Init()
    {
    }

    public virtual void UpdatePosition()
    {
        this.Position += this.Speed * this.MaxSpeed * Time.deltaTime;
    }


    private void OnBecameInvisible()
    {
       // BulletFactory.ReleaseBullet(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseAvatar avatar = collision.gameObject.GetComponent<BaseAvatar>();
        if (avatar != null)
        {
            avatar.TakeDamage(Damage);
            BulletFactory.ReleaseBullet(this);
        } else {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet != null)
            {
                BulletFactory.ReleaseBullet(this);
                BulletFactory.ReleaseBullet(bullet);
            }
        }
    }

    void Start()
    {
        Init();   
    }

    void Update()
    {
        UpdatePosition();   
    }
}
