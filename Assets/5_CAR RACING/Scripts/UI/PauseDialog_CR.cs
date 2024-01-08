using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseDialog_CR : Dialog
{
    [SerializeField] protected Text bestScoreText;

    public override void Show(bool isShow)
    {
        base.Show(isShow);
        if (bestScoreText != null)
        {
            bestScoreText.text = Prefs_TJ.bestScore.ToString();
        }
    }

    public virtual void Resume()
    {
        Time.timeScale = 1;
        Close();
    }

    public virtual void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BALL BREAKER");
    }
}
