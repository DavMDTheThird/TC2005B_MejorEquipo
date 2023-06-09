using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaSegura : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D enemigo)
    {
        Debug.Log("Enemigo.gameobject" + enemigo.gameObject.name);
        Debug.Log("Enemigo.gameobject" + enemigo.gameObject.tag);
        if(enemigo.gameObject.CompareTag("Enemigos")){
            Destroy(enemigo.gameObject);
        }
    }
}
