using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController_BB : MonoBehaviour
{
    public LevelSelectionDialog_BB levelSelection_BB;
    public void PlayGame()
    {
        if (levelSelection_BB != null)
        {
            levelSelection_BB.Show(true);
        }
    }
}
