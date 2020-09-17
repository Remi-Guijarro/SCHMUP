using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [SerializeField]
    private float fireRate;

    private float lastShot = 0.0f;

    public float FireRate
    {
        get
        {
            return this.fireRate;
        }

        set
        {
            this.fireRate = value;
        }
    }


    [SerializeField]
    private Bullet bulletPrefab;

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

    public void Fire()
    {
        if (Time.time > this.FireRate + lastShot)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            lastShot = Time.time;
        }
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
