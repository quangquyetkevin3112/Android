using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow_AS : MonoBehaviour
{
    bool m_isFiring;
    Rigidbody2D m_rb;

    private void Awake()
    {
        this.m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (this.m_isFiring)
        {
            Vector2 vec = m_rb.velocity;
            float alpha = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, alpha);
        }
    }

    public virtual void Fire(float force)
    {
        if (m_rb == null) return;
        this.m_rb.isKinematic = false;
        transform.parent = null;
        m_isFiring = true;
        m_rb.AddRelativeForce(new Vector2(force, 0), ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TargetController_AS tg = collision.GetComponent<TargetController_AS>();

        if (collision.CompareTag(TagConsts.Apple))
        {
            var c2D = collision.GetComponent<Collider2D>();
            
            if (c2D != null)
            {
                c2D.enabled = false;
            }
            collision.transform.SetParent(transform);
        }
        else if (collision.CompareTag(TagConsts.Head))
        {

        }

        if (tg)
        {
            tg.Falling();
        }
    }
}
