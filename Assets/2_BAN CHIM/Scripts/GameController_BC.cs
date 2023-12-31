using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_BC : Singleton<GameController_BC>
{
    [SerializeField] protected Bird_BC[] birds;
    [SerializeField] protected float spawnTime;
    [SerializeField] protected int timeCountingDown;

    int m_timeCountingDown;

    int m_birdKilled;
    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }

    bool m_isGameOver;
    public bool IsGameOver { get => m_isGameOver; set => m_isGameOver = value; }

    public override void Awake()
    {
        this.MakeSingleton(false);
        this.m_timeCountingDown = this.timeCountingDown;
    }

    public override void Start()
    {
        
        UiManager_BC.Ins.ShowGameGui(false);
        UiManager_BC.Ins.UpdateKilledCouting(this.m_birdKilled);
    }

    public virtual void PlayGame()
    {
        this.StartCoroutine(SpawnGame());
        this.StartCoroutine(this.TimeCoutingDown());
        UiManager_BC.Ins.ShowGameGui(true);
    }

    IEnumerator TimeCoutingDown()
    {
        while (this.m_timeCountingDown > 0)
        {
            yield return new WaitForSeconds(1);
            this.m_timeCountingDown--;

            if (this.m_timeCountingDown <= 0)
            {
                this.m_isGameOver = true;

                if (this.m_birdKilled > Prefs.bestScore)
                {
                    UiManager_BC.Ins.gameDialog.UpdateDialog("NEW BEST", "BEST KILLED : x" + m_birdKilled);
                }
                else
                {
                    UiManager_BC.Ins.gameDialog.UpdateDialog("YOUR BEST", "BEST KILLED : x" + Prefs.bestScore);
                }
                UiManager_BC.Ins.gameDialog.Show(true);
                UiManager_BC.Ins.Dialog = UiManager_BC.Ins.gameDialog;
                Prefs.bestScore = this.m_birdKilled;
            }
            UiManager_BC.Ins.UpdateTimer(IntToTime(this.m_timeCountingDown));
        }
    }

    IEnumerator SpawnGame()
    {
        while (!this.m_isGameOver)
        {
            this.SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    protected virtual void SpawnBird()
    {
        Vector3 spawnPos = Vector3.zero;

        float ranCheck = Random.Range(0f, 1f);

        if (ranCheck >= 0.5f)
        {
            spawnPos = new Vector3(12, Random.Range(1.5f, 4), 0);
        }
        else
        {
            spawnPos = new Vector3(-12, Random.Range(1.5f, 4), 0);
        }

        if (this.birds != null && this.birds.Length > 0)
        {
            int ranIdx = Random.Range(0, this.birds.Length);
            
            if (this.birds[ranIdx])
            {
                Bird_BC birdClone = Instantiate(this.birds[ranIdx], spawnPos, Quaternion.identity);
            }
        }
    }

    protected virtual string IntToTime(int time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
