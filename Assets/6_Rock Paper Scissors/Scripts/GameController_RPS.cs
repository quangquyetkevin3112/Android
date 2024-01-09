using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_RPS : Singleton<GameController_RPS>
{
    [SerializeField] protected AIController_RPS ai;

    public override void Start()
    {
        base.Start();
        AudioController_RPS.Ins.PlayBackgroundMusic();
    }

    protected virtual void CheckDecision(int decision)
    {
        if (ai)
        {
            ai.MakeDecision();
        }

        string resulf = "";

        switch (decision)
        {
            case TagConsts.Rock:
                switch (ai.curDecision)
                {
                    case TagConsts.Rock:
                        resulf = "Draw";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.drawSound);
                        break;
                    case TagConsts.Paper:
                        resulf = "Lose";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.loseSound);
                        break;
                    case TagConsts.Scissors:
                        resulf = "Win";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.winSound);
                        break;
                }
                break;
            case TagConsts.Paper:
                switch (ai.curDecision)
                {
                    case TagConsts.Rock:
                        resulf = "Win";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.winSound);
                        break;
                    case TagConsts.Paper:
                        resulf = "Draw";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.drawSound);
                        break;
                    case TagConsts.Scissors:
                        resulf = "Lose";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.loseSound);
                        break;
                }
                break;
            case TagConsts.Scissors:
                switch (ai.curDecision)
                {
                    case TagConsts.Rock:
                        resulf = "Lose";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.loseSound);
                        break;
                    case TagConsts.Paper:
                        resulf = "Win";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.winSound);
                        break;
                    case TagConsts.Scissors:
                        resulf = "Draw";
                        AudioController_RPS.Ins.PlaySound(AudioController_RPS.Ins.drawSound);
                        break;
                }
                break;
        }
        UiManager_RPS.Ins.UpdateResulf(resulf);
        StartCoroutine(this.Replay());
    }

    IEnumerator Replay()
    {
        yield return new WaitForSeconds(2);

        if (ai)
        {
            ai.ShowDecisionIcon(true);
        }

        UiManager_RPS.Ins.resulfText.gameObject.SetActive(false);
        UiManager_RPS.Ins.DeactiveDecisionBtns();
    }
}
