using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : MonoBehaviour
{
    [SerializeField] protected Image imgComp;
    [SerializeField] protected Color activeColor;
    [SerializeField] protected Color normalColor;

    public virtual void ActiveClick()
    {
        if (imgComp)
        {
            imgComp.color = activeColor;
        }
    }

    public virtual void DeactiveClick()
    {
        if (imgComp)
        {
            imgComp.color = normalColor;
        }
    }
}
