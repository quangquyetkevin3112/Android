using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController_RPS : MonoBehaviour
{
    [SerializeField] public int curDecision;
    [SerializeField] protected Image decisionIcon;
    [SerializeField] protected GameObject questionMark;

    public virtual void ShowDecisionIcon(bool isShow)
    {
        if (decisionIcon != null)
        {
            decisionIcon.gameObject.SetActive(isShow);
        }

        if (questionMark != null)
        {
            questionMark.gameObject.SetActive(!isShow);
        }
    }

    public virtual void MakeDecision()
    {
        curDecision = Random.Range(1, 4);

        this.ShowDecisionIcon(true);

        switch (curDecision) 
        {
            case TagConsts.Rock:
                decisionIcon.sprite = UiManager_RPS.Ins.rockSprite;
                break;
            case TagConsts.Paper:
                decisionIcon.sprite = UiManager_RPS.Ins.paperSprite;
                break;
            case TagConsts.Scissors:
                decisionIcon.sprite = UiManager_RPS.Ins.scissorsSprite;
                break;
        }
    }
}
