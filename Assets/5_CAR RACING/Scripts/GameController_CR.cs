using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_CR : Singleton<GameController_CR>
{
    [SerializeField] protected Obstacle_CR[] obstacles;
    [SerializeField] protected float spawnTime = 2;
    [SerializeField] protected int timeDelay = 3;

    int m_curTimeDelay;

    bool isGameOver;

    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    int m_score;
    public int Score { get => m_score; set => m_score = value; }

    public override void Start()
    {
        base.Start();
        this.m_curTimeDelay = timeDelay;
        UiManager_CR.Ins.UpdateScore(m_score);
        StartCoroutine(this.CoutingTime());
        StartCoroutine(this.GameSpawn());
        AudioController_CR.Ins.PlayBackgroundMusic();
    }

    IEnumerator CoutingTime()
    {
        while (m_curTimeDelay > 0)
        {
            yield return new WaitForSeconds(1);
            this.m_curTimeDelay--;

            if (this.m_curTimeDelay > 0)
            {
                AudioController_CR.Ins.PlaySound(AudioController_CR.Ins.timeBeep);
            }
            UiManager_CR.Ins.TimeCoutingDown(m_curTimeDelay);
        }
    }

   IEnumerator GameSpawn()
   {
        while (this.isGameOver)
        {
            this.SpawnObstacle();
            yield return new WaitForSeconds(spawnTime);
        }
   }
   
    protected virtual void SpawnObstacle()
    {
        Vector2 spawnPos = new Vector2(6, Random.Range(-1.6f, 1.6f));

        if (this.obstacles != null && this.obstacles.Length > 0)
        {
            int obstacle = Random.Range(0, this.obstacles.Length);

            if (this.obstacles[obstacle] != null)
            {
                Instantiate(this.obstacles[obstacle], spawnPos, Quaternion.identity);
            }
        }
    }

    public virtual void AddScore()
    {
        this.m_score++;
        Prefs_CR.bestScore = this.m_score;
        UiManager_CR.Ins.UpdateScore(m_score);
    }
}
