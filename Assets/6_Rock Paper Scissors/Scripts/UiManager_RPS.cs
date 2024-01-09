using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager_RPS : Singleton<UiManager_RPS>
{
    [SerializeField] public Sprite rockSprite;
    [SerializeField] public Sprite paperSprite;
    [SerializeField] public Sprite scissorsSprite;

    [SerializeField] public Text resulfText;
    [SerializeField] public DecisionButton[] decisionButtons;

    public override void Awake()
    {
        base.Awake();

    }

    public virtual void UpdateResulf(string resulf)
    {
        if (this.resulfText != null)
        {
            resulfText.text = resulf;
        }
    }

    public virtual void DeactiveDecisionBtns()
    {
        if (this.decisionButtons != null && this.decisionButtons.Length > 0)
        {
            for (int i = 0; i < this.decisionButtons.Length; i++)
            {
                DecisionButton decisionButton = this.decisionButtons[i];

                if (decisionButton != null)
                {
                    decisionButton.DeactiveClick();
                }
            }
        }
    }
}
