using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] protected int levelGoTo;
    [SerializeField] protected bool isUnlocked;
    [SerializeField] protected GameObject levelState;
    [SerializeField] protected Image icon;
    [SerializeField] protected Text levelText;
    [SerializeField] protected Sprite checkMap;
    [SerializeField] protected Sprite lockIcon;

    Button m_btnCom;

    private void Start()
    {
        if (levelText)
        {
            levelText.text = (levelGoTo + 1).ToString("00");
        }

        this.m_btnCom = GetComponent<Button>();

        if (this.m_btnCom)
        {
            m_btnCom.onClick.AddListener(() => GoToLevel());
        }

        if (!Prefs_BB.IsGameEntered())
        {
            Prefs_BB.SetLevelUnlocked(levelGoTo, isUnlocked);
        }

        if (Prefs_BB.IsLevelUnlocked(levelGoTo))
        {
            if (levelState)
            {
                levelState.SetActive(false);
            }

            if (Prefs_BB.IsLevelPassed(levelGoTo))
            {
                if (levelState)
                {
                    levelState.SetActive(true);

                    if (this.icon && this.checkMap)
                    {
                        icon.sprite = checkMap;
                    }
                }
            }
        }
        else
        {
            if (levelState)
            {
                levelState.SetActive(true);
            }

            if (this.icon && this.checkMap)
            {
                icon.sprite = this.lockIcon;
            }
        }
    }

    public virtual void GoToLevel()
    {
        if (Prefs_BB.IsLevelUnlocked(levelGoTo))
        {
            LevelManager_BB.Ins.Level = levelGoTo;
            SceneManager.LoadScene("BALL BREAKER");
        }
    }
}
