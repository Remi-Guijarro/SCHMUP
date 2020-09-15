using UnityEngine;
using UnityEditor;

public class EnemyAvatar : BaseAvatar {
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}