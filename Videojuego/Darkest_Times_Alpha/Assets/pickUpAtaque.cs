using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickUpAtaque : MonoBehaviour
{
    private inventarioPrueba invenPrueba;
    public GameObject itemButtom;

    private int precioObjeto;
    private int totalHuesos;
    private int valorPocionStamina = 1;
    private int valorEscudo = 2;


    /*public GameManager gameManager;*/


    private void Start()
    {
        invenPrueba = GameObject.FindGameObjectWithTag("Player").GetComponent<inventarioPrueba>();
    }

    public void PrecioObjeto(string objeto)
    {
        switch (objeto)
        {
            case "BotonStamina":
                precioObjeto = 1;
                break;
            case "BotonEscudo":
                precioObjeto = 2;
                break;
        }
    }

    public void AdquirirObjeto(string objeto)
    {
        PrecioObjeto(objeto);
        itemButtom = (GameObject)Resources.Load(objeto); // va dentro del if
        for (int i = 0; i < invenPrueba.slots.Length; i++)
        {
            if (invenPrueba.isFull[i] == false && precioObjeto <= GameManager.Instance.PuntosTotales)
            {
                totalHuesos = GameManager.Instance.PuntosTotales;
                GameManager.Instance.RestarPuntos(valorPocionStamina);
                invenPrueba.isFull[i] = true;
                Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleE")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == false)
                {
                    invenPrueba.isFull[i] = true;
                    Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleA")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == false)
                {
                    invenPrueba.isFull[i] = true;
                    Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleS")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == false)
                {
                    invenPrueba.isFull[i] = true;
                    Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
