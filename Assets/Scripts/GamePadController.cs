using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : Singleton<GamePadController>
{
    [SerializeField] protected bool isOnMobile;

    bool m_canMoveLeft;
    public bool CanMoveLeft { get => m_canMoveLeft; set => m_canMoveLeft = value; }

    bool m_canMoveRight;
    public bool CanMoveRight { get => m_canMoveRight; set => m_canMoveRight = value; }

    public override void Awake()
    {
        this.MakeSingleton(false);
    }

    private void Update()
    {
        if (!this.isOnMobile)
        this.PCInputHandles();
    }

    protected virtual void PCInputHandles()
    {
        this.m_canMoveLeft = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        this.m_canMoveRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }
}
