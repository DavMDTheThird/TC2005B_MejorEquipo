using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaSegura : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D enemigo)
    {
    Debug.Log(enemigo.gameObject.name);
        Debug.Log(enemigo.gameObject.tag);
    }
}
