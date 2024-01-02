using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController_BB : MonoBehaviour
{
    public LevelSelection_BB levelSelection_BB;
    public void PlayGame()
    {
        if (levelSelection_BB != null)
        {
            levelSelection_BB.Show(true);
        }
    }
}
