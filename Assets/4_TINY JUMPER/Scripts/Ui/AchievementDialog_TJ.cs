using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementDialog_TJ : Dialog
{
    [SerializeField] protected Text bestScoreText;

    public override void Show(bool isShow)
    {
        base.Show(isShow);
        if (bestScoreText != null )
        {
            bestScoreText.text = Prefs_TJ.bestScore.ToString();
        }
    }
}
