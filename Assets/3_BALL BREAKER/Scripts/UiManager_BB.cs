using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager_BB : Singleton<UiManager_BB>
{
    [SerializeField] protected Text scoreText;
    [SerializeField] protected Text timeCoutingDown;
    [SerializeField] public PauseDialog pauseDialog;
    [SerializeField] public WinDialog_BB winDialog;
    [SerializeField] public GameOverDialog_BB gameOverDialog;

    public override void Awake()
    {
        this.MakeSingleton(false);
    }

    public virtual void UpdateScore(int score)
    {
        if (this.scoreText)
        {
            this.scoreText.text = "SCORE : " + score.ToString("00"); 
        }
    }

    public virtual void TimeCoutingDown(int time)
    {
        if (this.timeCoutingDown)
        {
            this.timeCoutingDown.text = time.ToString("00");
        }

        if (time <= 0)
        {
            if (this.timeCoutingDown)
            {
                this.timeCoutingDown.gameObject.SetActive(false);
            }
        }
    }

    public virtual void BackToHome()
    {
        SceneManager.LoadScene("BALL BREAKER");
    }

    public virtual void PauseGame()
    {
        if (this.pauseDialog)
        {
            this.pauseDialog.Show(true);
        }
    }
}
