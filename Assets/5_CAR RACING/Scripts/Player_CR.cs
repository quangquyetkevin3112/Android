using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CR : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 300;

    bool isDead;
    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.LimitPos();
    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        if (this.isDead) return;

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
        if (transform.position.x >= 1.6f)
        {
            transform.position = new Vector3(1.6f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -1.6f)
        {
            transform.position = new Vector3(-1.6f, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.Obstacle))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            AudioController_CR.Ins.PlaySound(AudioController_CR.Ins.explosion);
        }
    }
}
