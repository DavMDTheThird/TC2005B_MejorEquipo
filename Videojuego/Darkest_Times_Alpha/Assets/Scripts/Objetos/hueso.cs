using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hueso : MonoBehaviour
{
    [Header("Sonido")]
    [SerializeField] private AudioClip colectar;
    public int valor = 1;
    //public GameManager gameManager;
    [SerializeField] private float cantidadPuntos;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        {
            // ControladorPuntos.Instance.sumarPuntos(valor);
            GameManager.Instance.SumarPuntos(valor);
            ControladorSonidos.Instance.EjecutarSonido(colectar);
            Destroy(this.gameObject);
        }
    }
}
