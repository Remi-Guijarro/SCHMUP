using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
   public override void Init()
    {
        base.Init();
        this.Speed = Vector2.right;
    }
}
