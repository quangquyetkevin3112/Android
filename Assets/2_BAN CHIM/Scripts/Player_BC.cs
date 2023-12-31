using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BC : MonoBehaviour
{
    [SerializeField] protected GameObject viewFind;
    [SerializeField] protected float fireRate = 2;

    bool m_isShooted;
    float m_fireRate;
    GameObject m_viewFindClone;

    private void Awake()
    {
        this.m_fireRate = this.fireRate;
    }

    private void Start()
    {
        if (this.viewFind)
        {
            this.m_viewFindClone = Instantiate(this.viewFind, Vector3.zero, Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !this.m_isShooted)
        {
            this.Shoot(mousePos);
        }

        if (this.m_isShooted)
        {
            this.m_fireRate -= Time.deltaTime;

            if (this.m_fireRate <= 0)
            {
                this.m_isShooted = false;
                this.m_fireRate = this.fireRate;
            }
            UiManager_BC.Ins.UpdateFireRate(this.m_fireRate / this.fireRate);
        }

        if (this.m_viewFindClone)
        {
            this.m_viewFindClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    protected virtual void Shoot(Vector3 mousePos) 
    {
        this.m_isShooted = true;

        Vector3 shootDir = Camera.main.transform.position - mousePos;
        shootDir.Normalize();

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);

        if (hits != null && hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                if (hit.collider != null && Vector3.Distance((Vector2)hit.transform.position, (Vector2)mousePos) <= 0.4f)
                {
                    Bird_BC bird = hit.collider.GetComponent<Bird_BC>();

                    if (bird != null)
                    {
                        bird.Die();
                    }
                }
            }
        }
        AudioController_BC.Ins.PlaySound(AudioController_BC.Ins.shootingSound);
        CineController.Ins.ShakeTrigger();
    }
}
