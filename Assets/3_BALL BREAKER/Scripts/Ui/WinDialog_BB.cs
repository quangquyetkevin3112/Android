using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinDialog_BB : Dialog
{
    [SerializeField] protected Text bestScoreText;

    public override void Show(bool isShow)
    {
        base.Show(isShow);
        Time.timeScale = 0;
        if (Prefs_BB.hasNewBest)
        {
            if (bestScoreText != null)
            {
                bestScoreText.text = "NEW BEST : " + Prefs_BB.bestScore.ToString("n0");
            }

        }
        else
        {
            if (bestScoreText != null)
            {
                bestScoreText.text = "BEST SCORE : " + Prefs_BB.bestScore.ToString("n0");
            }
        }

        AudioController_BB.Ins.PlaySound(AudioController_BB.Ins.win);
    }

    public virtual void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BALL BREAKER");
    }

    public virtual void Continue()
    {
        Time.timeScale = 1;
        LevelManager_BB.Ins.Level++;
        SceneManager.LoadScene("BALL BREAKER");
    }

    public virtual void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BALL BREAKER");
    }
}
