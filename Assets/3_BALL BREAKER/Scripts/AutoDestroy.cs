using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] protected float timeToDestroy;

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
