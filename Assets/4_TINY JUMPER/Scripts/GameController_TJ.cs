using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_TJ : Singleton<GameController_TJ>
{
    [SerializeField] public Player_TJ playerPrefab;
    [SerializeField] public Platform_TJ platformPrefab;
    [SerializeField] protected float minSpawnX = 2.5f;
    [SerializeField] protected float maxSpawnX = 3.5f;
    [SerializeField] protected float minSpawnY = -5.5f; 
    [SerializeField] protected float maxSpawnY = -3.5f;
    [SerializeField] public float powerBarUp = 1;
    [SerializeField] protected CamController_TJ camController;

    Player_TJ m_Player;
    int m_score;

    bool m_isGameStarted;
    public bool IsGameStarted => m_isGameStarted;

    public override void Awake()
    {
        this.MakeSingleton(false);
    }

    public override void Start()
    {
        this.PlayGame();   
        UiManager_TJ.Ins.UpdateScoreCouting(this.m_score);

        UiManager_TJ.Ins.UpdateFireRate(0, 1);
    }

    public virtual void PlayGame()
    {
        StartCoroutine(this.PlatInit());
        UiManager_TJ.Ins.ShowGameGui(true);
    }

    IEnumerator PlatInit()
    {
        Platform_TJ platformClone01 = null;
        
        if (this.platformPrefab)
        {
            platformClone01 = Instantiate(this.platformPrefab, new Vector2(0,Random.Range(minSpawnY, maxSpawnY)), Quaternion.identity);
            platformClone01.id = platformClone01.gameObject.GetInstanceID();
        }
        yield return new WaitForSeconds(1);

        if (this.playerPrefab)
        {
            this.m_Player = Instantiate(this.playerPrefab, Vector3.zero, Quaternion.identity);
            m_Player.lastPlatformId = platformClone01.id;
        }

        if (this.platformPrefab)
        {
            float spawnX = m_Player.transform.position.x + this.minSpawnX;
            float spawnY = Random.Range(minSpawnY, maxSpawnY);

            Platform_TJ platformClone02 = Instantiate(this.platformPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
            platformClone02.id = platformClone02.gameObject.GetInstanceID();
        }
        yield return new WaitForSeconds(1);

        this.m_isGameStarted = true;
    }

    public virtual void CreatePlatform()
    {
        if (!this.platformPrefab || !this.playerPrefab) return;

        float spawnX = Random.Range(this.m_Player.transform.position.x + this.minSpawnX, this.m_Player.transform.position.x + this.maxSpawnX);
        float spawnY = Random.Range(this.minSpawnY, this.maxSpawnY);

        Platform_TJ platformClone = Instantiate(this.platformPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
        platformClone.id = platformClone.gameObject.GetInstanceID();
    }

    public virtual void CreatePlatformAndLerp(float playPosX)
    {
        if (this.camController)
        {
            camController.LerpTrigger(playPosX + this.minSpawnX);
        }
        this.CreatePlatform();
    }

    public virtual void AddScore()
    {
        this.m_score++;
        Prefs_TJ.bestScore = this.m_score;
        UiManager_TJ.Ins.UpdateScoreCouting(this.m_score);
    }
}
