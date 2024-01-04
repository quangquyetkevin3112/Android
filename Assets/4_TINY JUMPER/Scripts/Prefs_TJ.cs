using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs_TJ : MonoBehaviour
{
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(PrefConsts_TJ.Best_Score, 0);
        set
        {
            int curBestScore = PlayerPrefs.GetInt(PrefConsts_TJ.Best_Score, 0);

            if (value > curBestScore)
            {
                PlayerPrefs.SetInt(PrefConsts_TJ.Best_Score, value);
            }
        }
    }
}
