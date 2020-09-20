using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    public LevelDescription Definition { get; set; }
    private float startTime;
    private List<EnemyDescription> Enemies;
    private bool[] spawnEnemy;

    public void Load(LevelDescription levelDescription)
    {
        startTime = Time.time;
        Enemies = new List<EnemyDescription>(levelDescription.EnemyDecription);
        this.spawnEnemy = new bool[Enemies.Count];
        for (int i = 0; i < Enemies.Count; i ++) {
            this.spawnEnemy[i] = false;
        }
    }
    public void Execute()
    {   
        float timePassedSinceBeginning = Time.time - this.startTime;
        for(int i = 0;  i < Enemies.Count; i++) {
            EnemyDescription enemyDescription = Enemies[i];
           if (enemyDescription.SpawnDate <= timePassedSinceBeginning && !spawnEnemy[i]) {
                EnemyFactory.Instance.GetEnemy(enemyDescription.SpawnPosition, Quaternion.identity, enemyDescription.PrefabPath);
                this.spawnEnemy[i] = true;
            }             
        }
    }
}
