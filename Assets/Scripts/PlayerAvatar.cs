using UnityEngine;
using UnityEditor;

public class PlayerAvatar : BaseAvatar {
    [SerializeField]
    private float maxEnergy;

    public float MaxEnergy
    {
        get
        {
            return this.maxEnergy;
        }

        set
        {
            this.maxEnergy = value;
        }
    }


    [SerializeField]
    private float energy;

    public float Energy
    {
        get
        {
            return this.energy;
        }

        set
        {
            this.energy = value;
        }
    }

    [SerializeField]
    private float energyGainingSpeed;

    public float EnergyGainingSpeed
    {
        get
        {
            return this.energyGainingSpeed;
        }

        set
        {
            this.energyGainingSpeed = value;
        }
    }

    public void DecreaseEnergy(float energyNeeded)
    {
        this.Energy -= energyNeeded;
    }

    public void ReloadEnergy()
    {
        if(this.Energy + this.EnergyGainingSpeed <= this.MaxEnergy)
        {
            this.Energy += this.EnergyGainingSpeed;
        }        
    }

    private void Start()
    {
        this.MaxSpeeed = 10;
    }

    private void FixedUpdate()
    {
       ReloadEnergy();
    }
}