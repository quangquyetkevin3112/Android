using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class Prefs_BB 
{
    public static bool hasNewBest;
    public static void SetBool(bool isTrue, string key)
    {
        if (isTrue)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }

    public static int bestScore
    {
        get => PlayerPrefs.GetInt(PrefConsts_BB.Best_Score, 0);
        set
        {
            if (value > PlayerPrefs.GetInt(PrefConsts_BB.Best_Score,0))
            {
                hasNewBest = true;
                PlayerPrefs.SetInt(PrefConsts_BB.Best_Score, value);
            }
            else
            {
                hasNewBest = false;
            }
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        return GetBool(PrefConsts_BB.Level_Unlocked + level);
    }

    public static bool IsLevelPassed(int level)
    {
        return GetBool(PrefConsts_BB.Level_Passed + level);
    }

    public static void SetLevelUnlocked(int level, bool unlock)
    {
        SetBool(unlock, PrefConsts_BB.Level_Unlocked + level);
    }

    public static void SetLevelPassed(int level, bool unlock)
    {
        SetBool(unlock, PrefConsts_BB.Level_Passed + level);
    }

    public static bool IsGameEntered()
    {
        return GetBool(PrefConsts_BB.Is_Game_Entered);
    }

    public static void SetGameEntered(bool isEntered)
    {
        SetBool(isEntered, PrefConsts_BB.Is_Game_Entered);
    }
}
