using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricker_BB : MonoBehaviour
{
    [SerializeField] protected int heath;
    [SerializeField] protected int minScore;
    [SerializeField] protected int maxScore;
    [SerializeField] protected GameObject ballHittedVfx;

    public int ScoreBonus
    {
        get => Random.Range(minScore, maxScore) * (GameController_BB.Ins.Level + 1);
    }

    public virtual void Hit()
    {
        this.heath--;

        if (this.heath <= 0)
        {
            if (this.ballHittedVfx)
            {
                Instantiate(ballHittedVfx, transform.position, Quaternion.identity);
                GameController_BB.Ins.AddScore(ScoreBonus);

                if (GameController_BB.Ins.LevelObj != null && GameController_BB.Ins.LevelObj.bricker != null)
                {
                    GameController_BB.Ins.LevelObj.bricker.Remove(this);
                    if (GameController_BB.Ins.LevelObj.bricker.Count <= 0)
                    {
                        Prefs_BB.SetLevelPassed(LevelManager_BB.Ins.Level, true);
                        Prefs_BB.SetLevelUnlocked(LevelManager_BB.Ins.Level + 1, true);
                        UiManager_BB.Ins.winDialog.Show(true);
                    }
                } 
                Destroy(gameObject);
            }
            AudioController_BB.Ins.PlaySound(AudioController_BB.Ins.bounci);
        }
    }
}
