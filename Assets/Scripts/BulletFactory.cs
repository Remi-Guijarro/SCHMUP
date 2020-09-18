using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private Dictionary<BulletType, Queue<Bullet>> bulletsAvailable = new Dictionary<BulletType, Queue<Bullet>>();

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

        foreach (object value in System.Enum.GetValues(typeof(BulletType)))
        {
            this.bulletsAvailable.Add((BulletType)value, new Queue<Bullet>());
        }
    }

    private void Start()
    {
      PreinstantiateBullets(BulletType.PlayerSimpleBullet, 20);
      PreinstantiateBullets(BulletType.EnemyBullet, 20);
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
        Queue<Bullet> availableBullets = Instance.bulletsAvailable[type];
        Bullet bullet = null;
        if (availableBullets.Count > 0)
        {
            bullet = availableBullets.Dequeue();
            bullet.Position = position;
        }

        if (bullet == null)
        {
            bullet = InstantiateBullet(type);
            bullet.Position = position;
        }
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    private static Bullet InstantiateBullet(BulletType type)
    {
        Bullet bullet = null;
        switch (type)
        {
            case BulletType.EnemyBullet:
                bullet = Instantiate(Instance.EnemyBulletPrefab);
                break;
            case BulletType.PlayerSimpleBullet:
                bullet = Instantiate(Instance.SimpleBulletPrefab);         
                break;
            default:
                break;
        }
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public static void ReleaseBullet(Bullet bullet)
    {
        Queue<Bullet> availableBullets = Instance.bulletsAvailable[bullet.Type];
        bullet.gameObject.SetActive(false);
        availableBullets.Enqueue(bullet);
    }

    private void PreinstantiateBullets(BulletType bulletType, int numberOfBulletsToPreinstantiate)
    {
        Queue<Bullet> bullets = Instance.bulletsAvailable[bulletType];
        for (int index = 0; index < numberOfBulletsToPreinstantiate; index++)
        {
            Bullet bullet = InstantiateBullet(bulletType);
            if (bullet == null)
            {
                Debug.LogError(string.Format("Failed to instantiate {0} bullets.", numberOfBulletsToPreinstantiate));
                break;
            }

            bullets.Enqueue(bullet);
        }
    }
}
