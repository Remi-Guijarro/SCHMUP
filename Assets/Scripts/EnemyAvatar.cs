using UnityEngine;
using UnityEditor;

public class EnemyAvatar : BaseAvatar {
    private void OnBecameInvisible()
    {
        EnemyFactory.ReleaseEnemy(this);
    }

    public override string PrefabPath { get => "Prefabs/Enemy"; set => base.PrefabPath = value; }
}