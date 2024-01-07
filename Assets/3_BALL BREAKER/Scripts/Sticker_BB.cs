using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker_BB : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 300;

    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    private void Update()
    {
        this.LimitPos();
    }

    protected virtual void Moving()
    {
        if (!this.m_rb) return;

        if (GamePadController.Ins.CanMoveLeft)
        {
            this.m_rb.velocity = Vector2.left * this.moveSpeed * Time.deltaTime;    
        }
        else if (GamePadController.Ins.CanMoveRight)
        {
            this.m_rb.velocity = Vector2.right * this.moveSpeed * Time.deltaTime;
        }
        else
        {
            this.m_rb.velocity = Vector2.zero;
        }
    }

    protected virtual void LimitPos()
    {
        if (transform.position.x >= 2)
        {
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -2)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
    }
}
