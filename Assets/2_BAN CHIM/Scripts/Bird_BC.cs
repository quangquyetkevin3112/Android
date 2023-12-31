using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_BC : MonoBehaviour
{
    [SerializeField] protected float xSpeed = 3;
    [SerializeField] protected float yMinSpeed = -2;
    [SerializeField] protected float yMaxSpeed = 1.5f;
    [SerializeField] protected GameObject deathVfx;

    bool m_CanMovingLeft;
    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.RandomMovingDirection();
    }

    private void Update()
    {
        this.m_rb.velocity = this.m_CanMovingLeft ?
            new Vector2(-this.xSpeed, Random.Range(this.yMinSpeed, this.yMaxSpeed)) :
            new Vector2(this.xSpeed, Random.Range(this.yMinSpeed, this.yMaxSpeed));
        this.Filip();
    }

    protected virtual void RandomMovingDirection()
    {
        this.m_CanMovingLeft = transform.position.x > 0 ? true : false;
    }

    protected virtual void Filip()
    {
        if (this.m_CanMovingLeft)
        {
            if (transform.localScale.x < 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        GameController_BC.Ins.BirdKilled++;

        if (this.deathVfx)
        {
            Instantiate(this.deathVfx, transform.position, Quaternion.identity);
        }
        UiManager_BC.Ins.UpdateKilledCouting(GameController_BC.Ins.BirdKilled);
        
    }
}
