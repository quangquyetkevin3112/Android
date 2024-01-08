using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_CR : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 3;

    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (this.m_rb != null)
        {
            this.m_rb.velocity = Vector2.down * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagConsts.DeadZone))
        {
            GameController_CR.Ins.AddScore();
        }
    }
}
