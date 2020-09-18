using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void Init()
    {
        base.Init();
        this.Speed = Vector2.left;
        this.Type = BulletFactory.BulletType.EnemyBullet;
    }
}
