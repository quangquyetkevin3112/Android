using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_AS : MonoBehaviour
{
    [SerializeField] protected Arrow_AS arrowPb;
    [SerializeField] protected float drag;
    [SerializeField] protected float fire;
    [SerializeField] protected Transform arrowPoint;
    [SerializeField] protected Transform arrowSpawnPoint;
    [SerializeField] protected Transform arrowDirection;

    float m_minLimit;
    float m_maxLimit;
    Vector2 m_dragPos1;
    Vector2 m_dragPos2;
    float m_dragDist;
    bool m_isDragging;
    Arrow_AS m_arrowClone;

    private void Start()
    {
        this.SpawnArrow();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.m_isDragging = true;
            this.m_dragPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            this.m_isDragging = false;
            arrowPoint.localPosition = new Vector3(m_maxLimit, 0, 0);
            arrowDirection.localScale = new Vector3(0, 0, 0);

            if (m_dragDist > 0.1f)
            {
                this.Fire();
            }
        }

        if (m_isDragging)
        {
            m_dragPos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_dragDist = Vector2.Distance(m_dragPos1, m_dragPos2) * drag;
            if (m_dragDist <= 0.05f) return;

            var dragDir = new Vector2(m_dragPos1.x - m_dragPos2.x, m_dragPos1.y - m_dragPos2.y);
            float alpha = Mathf.Atan2(dragDir.y, dragDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, alpha);

            float dragX = m_maxLimit - m_dragDist;
            dragX = Mathf.Clamp(dragX, m_minLimit, m_maxLimit);
            arrowPoint.localPosition = new Vector3(dragX, 0, 0);

            float dirPointScaleX = Mathf.Clamp(m_dragDist, 0, 0.5f) * 2;
            arrowDirection.localScale = new Vector3(dirPointScaleX, 1, 1);
        }     
    }

    protected virtual void SpawnArrow()
    {
        if (arrowPb == null) return;
        m_arrowClone = Instantiate(arrowPb);    
        m_arrowClone.transform.SetParent(arrowSpawnPoint, false);
        m_arrowClone.transform.localScale = Vector3.one;
        m_arrowClone.transform.localPosition = arrowSpawnPoint.localPosition;
    }

    IEnumerator SpawnNextArrow(float time)
    {
        yield return new WaitForSeconds(time);
        this.SpawnArrow();
    }

    protected virtual void Fire()
    {
        if (m_arrowClone == null) return;
        float m_curForce = Mathf.Clamp(m_dragDist, 0, 0.5f) * fire;
        m_arrowClone.Fire(m_curForce);
        StartCoroutine(SpawnNextArrow(0.2f));
    }
}
