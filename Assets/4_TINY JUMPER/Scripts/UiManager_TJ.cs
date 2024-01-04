using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager_TJ : Singleton<UiManager_TJ>
{
    [SerializeField] protected GameObject homeGui;
    [SerializeField] protected GameObject gameGui;
    [SerializeField] protected Text scoreCoutingText;
    [SerializeField] protected Image powerBarSlider;
    [SerializeField] protected Dialog achievementDialog;
    [SerializeField] protected Dialog helpDilog;
    [SerializeField] protected Dialog gameOverDialog;

    public override void Awake()
    {
        base.Awake();
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

    public virtual void UpdateScoreCouting(int score)
    {
        if (this.scoreCoutingText)
        {
            this.scoreCoutingText.text = score.ToString();
        }
    }

    public virtual void UpdateFireRate(float curVal, float totalVal)
    {
        if (this.powerBarSlider)
        {
            powerBarSlider.fillAmount = curVal/totalVal;
        }
    }

    public virtual void AchievementDialog()
    {
        if (this.achievementDialog)
        {
            this.achievementDialog.Show(true);
        }
    }

    public virtual void HelpDialog()
    {
        if (this.helpDilog)
        {
            this.helpDilog.Show(true);
        }
    }

    public virtual void GameOverDialog()
    {
        if (this.gameOverDialog)
        {
            this.gameOverDialog.Show(true);
        }
    }
}
