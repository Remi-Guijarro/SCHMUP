using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private Slider energySlider;

    [SerializeField]
    private PlayerAvatar playerPrefab;


    void Start()
    {
        healthSlider.maxValue = playerPrefab.MaxHealth;
        healthSlider.value = playerPrefab.Health;
        energySlider.maxValue = playerPrefab.MaxEnergy;
        energySlider.value = playerPrefab.Energy;
        PlayerAvatar.OnHealthChanged += WhenHealthHasChanged;
        PlayerAvatar.OnEnergyChanged += WhenEnergyHasChanged;
        PlayerAvatar.OnDieEvent += WhenDeathHasOccured;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenHealthHasChanged(PlayerAvatar avatar, float oldValue, float newValue)
    {
        healthSlider.value = newValue;
    }

    public void WhenEnergyHasChanged(PlayerAvatar avatar, float oldValue, float newValue)
    {
        energySlider.value = newValue;
    }

    public void WhenDeathHasOccured(PlayerAvatar avatar)
    {
        // TO DO 
    }
}
