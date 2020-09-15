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

    public virtual void Init()
    {

    }

    public virtual void UpdatePosition()
    {

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
