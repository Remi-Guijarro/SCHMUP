using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager INSTANCE;

    [SerializeField]
    private BaseAvatar playerPrefab;

    [SerializeField]
    private TextAsset levelsDatabase;

    public BaseAvatar PlayerPrefab
    {
        get
        {
            return this.playerPrefab;
        }

        set
        {
            this.playerPrefab = value;
        }
    }

    [SerializeField]
    private BaseAvatar enemyPrefab; 

    public BaseAvatar EnemyPrefab
    {
        get
        {
            return this.enemyPrefab;
        }

        set
        {
            this.enemyPrefab = value;
        }
    }

    [SerializeField]
    private GameObject backgroundPrefab;

    public GameObject BackgroundPrefab
    {
        get
        {
            return this.backgroundPrefab;
        }

        set
        {
            this.backgroundPrefab = value;
        }
    }

    public List<LevelDescription> LevelDescriptions
    {
        get;

        set;
    }

    public Level CurrentLevel
    {
        get;

        set;
    }

    public static GameManager getInstance()
    {
        if(INSTANCE == null)
        {
            INSTANCE = new GameManager();
        }
        return INSTANCE;
    }

    public void InstantiatePlayer()
    {
        Instantiate(playerPrefab);
    }

    public void InstantiateEnemy()
    {
        float x = Camera.main.ViewportToWorldPoint(new Vector2(1.1f, 0f)).x;
        float y = Random.Range(Camera.main.orthographicSize * -1, Camera.main.orthographicSize);
        EnemyFactory.Instance.GetEnemy(new Vector2(x, y), Quaternion.identity,EnemyPrefab.PrefabPath);
    }

    public void InstantiateBackground()
    {
        Instantiate(BackgroundPrefab);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.LevelDescriptions = XmlHelpers.DeserializeDatabaseFromXML<LevelDescription>(this.levelsDatabase);
        InstantiateBackground();
        InstantiatePlayer();
        InvokeRepeating("InstantiateEnemy", 5f, 2f);
    }
}
