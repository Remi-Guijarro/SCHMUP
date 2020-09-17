using UnityEngine;
using UnityEditor;

public class PlayerAvatar : BaseAvatar {

    [SerializeField]
    private float energy;

    private void Start()
    {
        this.MaxSpeeed = 10;
    }
}