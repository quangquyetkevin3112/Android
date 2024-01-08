using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop_CR : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 3;
    [SerializeField] protected Transform bg1;
    [SerializeField] protected Transform bg2;
    [SerializeField] protected bool isStart;

    float m_ySize;

    private void Awake()
    {
        this.m_ySize = bg1.GetComponent<BoxCollider2D>().size.y * bg1.transform.localScale.y;
        this.bg1.transform.position = Vector3.zero;
        this.bg2.transform.position = new Vector3(bg1.transform.position.x, bg1.transform.position.y + this.m_ySize, 0);
    }

    private void Update()
    {
        if (!this.isStart) return;

        transform.Translate(Vector2.down * this.moveSpeed * Time.deltaTime);

        if (bg1.transform.position.y <= -this.m_ySize)
        {
            this.bg1.transform.position = new Vector3(bg2.transform.position.x, bg2.transform.position.y + this.m_ySize, 0);
            Transform temp = this.bg1;
            this.bg1 = this.bg2;
            this.bg2 = temp;
        }
    }
}
