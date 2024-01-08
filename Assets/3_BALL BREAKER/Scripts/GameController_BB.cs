using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_BB : Singleton<GameController_BB>
{
    [SerializeField] protected Ball_BB ball;
    [SerializeField] protected int timeDelay = 3;
    
    int m_curTimeDelay;

    int m_level;
    public int Level { get => m_level;  }

    int m_score;
    public int Score { get => m_score; set => m_score = value; }

    BrickManager_BB m_levelObj;
    public BrickManager_BB LevelObj { get => m_levelObj; }

    public override void Awake()
    {
        this.MakeSingleton(false);
    }

    public override void Start()
    {
        this.m_curTimeDelay = this.timeDelay;
        StartCoroutine(this.CoutingDown());
        Prefs_BB.hasNewBest = false;
        UiManager_BB.Ins.UpdateScore(m_score);
        AudioController_BB.Ins.PlayBackgroundMusic();
    }

    IEnumerator CoutingDown()
    {
        BrickManager_BB[] levelPrefabs = LevelManager_BB.Ins.levelPrefab;

        if (levelPrefabs != null && levelPrefabs.Length > 0 && levelPrefabs.Length > LevelManager_BB.Ins.Level)
        {
            BrickManager_BB levelPrefab = levelPrefabs[LevelManager_BB.Ins.Level]; 

            if (levelPrefab != null)
            {
                m_level = LevelManager_BB.Ins.Level;
                m_levelObj = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
            }
        }

        while (this.m_curTimeDelay > 0)
        {
            yield return new WaitForSeconds(1);
            this.m_curTimeDelay--;

            if (this.m_curTimeDelay > 0)
            {
                AudioController_BB.Ins.PlaySound(AudioController_BB.Ins.timeBeep);
            }
            else
            {
                AudioController_BB.Ins.PlaySound(AudioController_BB.Ins.ballStartTrigger);
            }
            UiManager_BB.Ins.TimeCoutingDown(m_curTimeDelay);
        }

        if (this.ball)
        {
            ball.Trigger();
        }

        Prefs_BB.SetGameEntered(true);
    }

    public virtual void AddScore(int score)
    {
        this.m_score += score;
        Prefs_BB.bestScore = m_score;
        UiManager_BB.Ins.UpdateScore(m_score);
    }
}
