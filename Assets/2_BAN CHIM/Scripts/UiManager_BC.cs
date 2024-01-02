using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager_BC : Singleton<UiManager_BC>
{
    [SerializeField] protected GameObject homeGui;
    [SerializeField] protected GameObject gameGui;
    [SerializeField] public Dialog gameDialog;
    [SerializeField] public Dialog pauseDialog;
    [SerializeField] protected Image fireRateKilled;
    [SerializeField] protected Text timerText;
    [SerializeField] protected Text killedCoutingText;

    Dialog m_curDiaLog;
    public Dialog Dialog { get => m_curDiaLog; set => m_curDiaLog = value; }

    public override void Awake()
    {
        this.MakeSingleton(false);
    }

    public virtual void ShowGameGui(bool isShow)
    {
        if (this.homeGui)
        {
            this.homeGui.SetActive(!isShow);
        }

        if (this.gameGui)
        {
            this.gameGui.SetActive(isShow);
        }
    }

    public virtual void UpdateTimer(string txt)
    {
        if (this.timerText)
        {
            this.timerText.text = txt;
        }
    }

    public virtual void UpdateKilledCouting(int killed)
    {
        if (this.killedCoutingText)
        {
            this.killedCoutingText.text = "x " + killed.ToString();
        }
    }

    public virtual void UpdateFireRate(float rate)
    {
        if (this.fireRateKilled)
        {
            fireRateKilled.fillAmount = rate;
        }
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0;

        if (this.pauseDialog)
        {
            this.pauseDialog.Show(true);
            this.pauseDialog.UpdateDialog("YOUR BEST", "BEST KILLED : x" + Prefs_BC.bestScore);
            m_curDiaLog = pauseDialog;
        }
    }

    public virtual void ResumeGame()
    {
        Time.timeScale = 1;

        if (this.m_curDiaLog)
        {
            this.m_curDiaLog.Show(false);
        }
    }

    public virtual void BackToHome()
    {
        this.ResumeGame();
        SceneManager.LoadScene("BAN CHIM");
    }

    public virtual void Replay()
    {
        if (this.m_curDiaLog)
        {
            this.m_curDiaLog.Show(false);
        }
        SceneManager.LoadScene("BAN CHIM");

    }

    public virtual void Exit()
    {
        this.ResumeGame();
        SceneManager.LoadScene("BAN CHIM");
        Application.Quit();
    }
}
