using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendedorTienda : MonoBehaviour
{
    [SerializeField] private GameObject tienda;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tienda.SetActive(false);
        if(collision.CompareTag("Player"))
        {
            tienda.SetActive(true);
        }
    }

}
