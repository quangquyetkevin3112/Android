using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_BB : MonoBehaviour
{
    [SerializeField] protected float moveForce = 180;
    [SerializeField] protected float maxVel = 4;

    bool m_isTriggerd;
    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (this.m_rb && m_isTriggerd)
        {
            this.m_rb.velocity = new Vector2(Mathf.Clamp(this.m_rb.velocity.x, -maxVel, maxVel), Mathf.Clamp(this.m_rb.velocity.y, -maxVel, maxVel));
        }
    }

    public virtual void Trigger()
    {
        if (this.m_rb)
        {
            m_isTriggerd = true;
            m_rb.isKinematic = false;
            m_rb.AddForce(new Vector2(moveForce, moveForce));
            transform.parent.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.Brick))
        {
            Bricker_BB bricker = collision.gameObject.GetComponent<Bricker_BB>();

            if (bricker != null)
            {
                bricker.Hit();
            }
        }

        if (collision.gameObject.CompareTag(TagConsts.Sticker))
        {
            if (this.m_rb.velocity.x > 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(this.moveForce, this.moveForce));
            }
            else if (this.m_rb.velocity.x < 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(-this.moveForce, this.moveForce));
            }
        }

        if (collision.gameObject.CompareTag(TagConsts.Wall_Top))
        {
            if (this.m_rb.velocity.x > 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(this.moveForce, -this.moveForce));
            }else if (this.m_rb.velocity.x < 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(-this.moveForce, -this.moveForce));
            }
        }

        if (collision.gameObject.CompareTag(TagConsts.Wall_Left))
        {
            if (this.m_rb.velocity.y > 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(this.moveForce, this.moveForce));
            }
            else if (this.m_rb.velocity.y < 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(this.moveForce, -this.moveForce));
            }
        }

        if (collision.gameObject.CompareTag(TagConsts.Wall_Right))
        {
            if (this.m_rb.velocity.y > 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(-this.moveForce, this.moveForce));
            }
            else if (this.m_rb.velocity.y < 0)
            {
                this.m_rb.velocity = Vector2.zero;
                this.m_rb.AddForce(new Vector2(-this.moveForce, -this.moveForce));
            }
        }
    }

    IEnumerator OpenGameOverDialog()
    {
        yield return new WaitForSeconds(1);
        UiManager_BB.Ins.gameOverDialog.Show(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.DeadZone))
        {
            CineController.Ins.ShakeTrigger();
            this.StartCoroutine(OpenGameOverDialog());
            AudioController_BB.Ins.PlaySound(AudioController_BB.Ins.lose);
        }
    }
}
