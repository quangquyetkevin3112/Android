using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs_BC
{
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(GameConsts_BC.BEST_SCORE, 0);
        set
        {
            int curBestScore = PlayerPrefs.GetInt(GameConsts_BC.BEST_SCORE);

            if (value > curBestScore)
            {
                PlayerPrefs.SetInt(GameConsts_BC.BEST_SCORE, value);
            }
        }
    }
}
