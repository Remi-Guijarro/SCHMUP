using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private Dictionary<string, Queue<EnemyAvatar>> availableEnemiesByType = new Dictionary<string, Queue<EnemyAvatar>>();

    public static EnemyFactory Instance
    {
        get;
        set;
    }

    public EnemyAvatar GetEnemy(Vector2 position, Quaternion rotation, string prefabPath)
    {
        if (!Instance.availableEnemiesByType.ContainsKey(prefabPath))
        {
            Instance.availableEnemiesByType.Add(prefabPath, new Queue<EnemyAvatar>());
        }

        Queue<EnemyAvatar> availableEnemies = Instance.availableEnemiesByType[prefabPath];

        EnemyAvatar enemy = null;
        if (availableEnemies.Count > 0)
        {
            enemy = availableEnemies.Dequeue();
        }

        if (enemy == null)
        {
            GameObject gameObject = null;
            GameObject prefab = (GameObject)Resources.Load(prefabPath);
            gameObject = Instantiate(prefab, position, rotation);
            gameObject.transform.parent = Instance.gameObject.transform;
            enemy = gameObject.GetComponent<EnemyAvatar>();
        }

        enemy.Position = position;
        enemy.gameObject.SetActive(true);

        return enemy;
    }

    public static void ReleaseEnemy(EnemyAvatar enemyAvatar)
    {
        Queue<EnemyAvatar> availableEnemies = Instance.availableEnemiesByType[enemyAvatar.PrefabPath];
        enemyAvatar.gameObject.SetActive(false);
        availableEnemies.Enqueue(enemyAvatar);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is multiple instance of singleton EnemyFactory");
            return;
        }

        Instance = this;
    }
}
