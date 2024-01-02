using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_BB : Singleton<LevelManager_BB>
{
    [SerializeField] public BrickManager_BB[] levelPrefab;

    int m_curLevel;
    public int Level { get => m_curLevel; set => m_curLevel = value; }
}
