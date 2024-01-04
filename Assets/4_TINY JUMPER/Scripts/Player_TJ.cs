using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TJ : MonoBehaviour
{
    [SerializeField] protected Vector2 jumpForce;
    [SerializeField] protected Vector2 jumpForceUp;
    [SerializeField] protected float minForceX = 3;
    [SerializeField] protected float maxForceX = 6.5f;
    [SerializeField] protected float minForceY = 3;
    [SerializeField] protected float maxForceY = 13.5f;

    [HideInInspector]
    public int lastPlatformId;
    float m_curPowerBarVal = 0;
    bool m_powerStetted;
    bool m_didJump;
    Rigidbody2D m_rb;
    Animator m_ai;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
        this.m_ai = GetComponent<Animator>();
    }

    private void Update()
    {
        this.SetPower();

        if (GameController_TJ.Ins.IsGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.SetPower(true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                this.SetPower(false);
            }
        }
    }

    protected virtual void SetPower()
    {
        if (this.m_powerStetted && !this.m_didJump)
        {
            this.jumpForce.x += this.jumpForceUp.x * Time.deltaTime;
            this.jumpForce.y += this.jumpForceUp.y * Time.deltaTime;

            this.jumpForce.x = Mathf.Clamp(this.jumpForce.x, this.minForceX, this.maxForceX);
            this.jumpForce.x = Mathf.Clamp(this.jumpForce.y, this.minForceY, this.maxForceY);

            m_curPowerBarVal += GameController_TJ.Ins.powerBarUp * Time.deltaTime;
            UiManager_TJ.Ins.UpdateFireRate(m_curPowerBarVal, 1);
        }
    }

    protected virtual void SetPower(bool isHoldingMouse)
    {
        m_powerStetted = isHoldingMouse;

        if (!this.m_powerStetted && !this.m_didJump)
        {
            this.Jump();
        }
    }

    protected virtual void Jump()
    {
        if (this.m_rb != null || jumpForce.x <= 0 || jumpForce.y <= 0) return;

        this.m_rb.velocity = jumpForce;

        m_didJump = true;

        if (m_ai)
        {
            m_ai.SetBool("didJump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.Ground))
        {
            Platform_TJ p = collision.transform.root.GetComponent<Platform_TJ>();

            if (this.m_didJump)
            {
                this.m_didJump = false;

                if (m_ai)
                {
                    m_ai.SetBool("didJump", false);
                }

                if (this.m_rb)
                {
                    this.m_rb.velocity = Vector2.zero;
                }

                this.m_curPowerBarVal = 0;
                UiManager_TJ.Ins.UpdateFireRate(this.m_curPowerBarVal, 1);
            }

            if (p && p.id != this.lastPlatformId)
            {
                GameController_TJ.Ins.CreatePlatformAndLerp(transform.position.x);
                lastPlatformId = p.id;
                GameController_TJ.Ins.AddScore();
            }
        }

        if (collision.gameObject.CompareTag(TagConsts.DeadZone))
        {
            UiManager_TJ.Ins.GameOverDialog();
            Destroy(collision.gameObject);
        }
    }
}
