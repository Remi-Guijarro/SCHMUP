using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
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
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();   
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();   
    }
}
