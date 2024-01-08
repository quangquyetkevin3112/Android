using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs_CR : MonoBehaviour
{
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(PrefConsts_TJ.Best_Score, 0);
        set
        {
            if (value > PlayerPrefs.GetInt(PrefConsts_CR.Best_Score, 0))
            {
                PlayerPrefs.SetInt(PrefConsts_CR.Best_Score, value);
            }
        }
    }
}
