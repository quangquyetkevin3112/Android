using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController_TJ : MonoBehaviour
{
    [SerializeField] protected float lerpTime = 1.5f;
    [SerializeField] protected float xOffset = 1;

    bool m_canLerp;
    float m_lerpXDist;

    private void Update()
    {
        if (this.m_canLerp) 
        this.MoveLerp();
    }

    protected virtual void MoveLerp()
    {
        float xPos = transform.position.x;
        xPos = Mathf.Lerp(xPos, m_lerpXDist, lerpTime * Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        if (transform.position.x >= (this.m_lerpXDist - xOffset))
        {
            m_canLerp = false;
        }
    }

    public virtual void LerpTrigger(float dist)
    {
        m_canLerp = true;
        m_lerpXDist = dist;
    }
}
