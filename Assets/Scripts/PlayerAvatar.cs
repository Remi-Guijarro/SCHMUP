using UnityEngine;
using UnityEditor;

public class PlayerAvatar : BaseAvatar {

    public delegate void HandleHealthChanged(PlayerAvatar source, float oldValue, float newValue);

    public static event HandleHealthChanged OnHealthChanged;

    public delegate void HandleEnergyChanged(PlayerAvatar source, float oldValue, float newValue);

    public static event HandleHealthChanged OnEnergyChanged;

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
        float previous = this.Energy;
        this.Energy -= energyNeeded;
        InvokeEnergyChanged(previous, this.Energy);
    }

    public void ReloadEnergy()
    {
        if(this.Energy + this.EnergyGainingSpeed <= this.MaxEnergy)
        {
            float previous = this.Energy;
            this.Energy += this.EnergyGainingSpeed;
            InvokeEnergyChanged(previous, this.Energy);
        }        
    }

    private void Start()
    {
        this.MaxSpeeed = 10;
    }
    
    protected virtual void InvokeHealthChanged(float oldValue, float newValue)
    {
        OnHealthChanged?.Invoke(this,oldValue, newValue);
    }

    protected virtual void InvokeEnergyChanged(float oldValue, float newValue)
    {
        OnEnergyChanged?.Invoke(this, oldValue, newValue);
    }

    public override void TakeDamage(float damage)
    {
        float previousHealth = this.Health;
        base.TakeDamage(damage);
        InvokeHealthChanged(previousHealth, this.Health);
    }

    private void FixedUpdate()
    {
       ReloadEnergy();
    }
}