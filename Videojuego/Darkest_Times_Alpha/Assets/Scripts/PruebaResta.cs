using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaResta : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            // ControladorPuntos.Instance.sumarPuntos(valor);
            GameManager.Instance.RestarPuntos(valor);
        }
    }
}
