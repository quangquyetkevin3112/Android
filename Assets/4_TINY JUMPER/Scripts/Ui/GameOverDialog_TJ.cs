using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine.Utility;

public class GameOverDialog_TJ : Dialog
{
    [SerializeField] protected Text bestScoreText;
    bool m_replayBtnClick;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

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
        this.m_replayBtnClick = true;
        SceneManager.LoadScene("TINY JUMPER");
    }

    public virtual void BackToHome()
    {
        UiManager_TJ.Ins.ShowGameGui(false);
        SceneManager.LoadScene("TINY JUMPER");
    }

    protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode modle)
    {
        if (m_replayBtnClick)
        {
            UiManager_TJ.Ins.ShowGameGui(true);
            GameController_TJ.Ins.PlayGame();
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
