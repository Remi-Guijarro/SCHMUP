using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{

    public static BulletFactory Instance
    {
        get;
        set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is multiple instance of singleton BulletsFactory");
            return;
        }

        Instance = this;
    }

    public enum BulletType
    {
        EnemyBullet,
        PlayerSimpleBullet
    }

    [SerializeField]
    private SimpleBullet SimpleBulletPrefab;

    [SerializeField]
    private EnemyBullet EnemyBulletPrefab;

    public Bullet GetBullet(BulletType type, Vector2 position)
    {
        Bullet bullet = null;
        switch (type)
        {
            case BulletType.EnemyBullet:
                Instantiate(EnemyBulletPrefab, position, Quaternion.identity);
                bullet = EnemyBulletPrefab;
                break;
            case BulletType.PlayerSimpleBullet:
                Instantiate(SimpleBulletPrefab, position, Quaternion.identity);
                bullet = SimpleBulletPrefab;
                break;
            default:
                break;
        }
        return bullet;
    }
}
