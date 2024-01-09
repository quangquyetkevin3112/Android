using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController_AS : MonoBehaviour
{
    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;

    float m_curSpeed;
    bool m_isFalling;
    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.m_curSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        
    }

    public virtual void Falling()
    {
        this.m_isFalling = true;

        if (this.m_rb != null)
        {
            m_rb.isKinematic = false;
            m_rb.velocity = Vector2.down * 3;
        }
    }
}
