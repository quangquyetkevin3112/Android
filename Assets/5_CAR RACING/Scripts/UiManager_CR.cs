using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager_CR : Singleton<UiManager_CR>
{
    [SerializeField] protected Text scoreText;
    [SerializeField] protected Text timeCoutingText;
    [SerializeField] protected PauseDialog_CR pause;
    [SerializeField] protected GameOverDialog_CR gameOver;

    public override void Awake()
    {
        base.Awake();
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
        if (this.timeCoutingText)
        {
            this.timeCoutingText.text = time.ToString("00");
        }

        if (time <= 0)
        {
            if (this.timeCoutingText)
            {
                this.timeCoutingText.gameObject.SetActive(false);
            }
        }
    }

    public virtual void PauseGame()
    {
        if (this.pause)
        {
            this.pause.gameObject.SetActive(true);
        }
    }
}
