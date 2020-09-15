using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
