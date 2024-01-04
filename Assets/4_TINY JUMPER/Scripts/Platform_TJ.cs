using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_TJ : MonoBehaviour
{
    [SerializeField] public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
