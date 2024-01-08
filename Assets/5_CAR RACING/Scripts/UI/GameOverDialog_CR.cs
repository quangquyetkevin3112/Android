using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDialog_CR : Dialog
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

    public virtual void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("CAR RACING");
    }

    public virtual void Exit()
    {
        Time.timeScale = 1.0f;
        Application.Quit();
    }
}
