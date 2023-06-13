using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickUpAtaque : MonoBehaviour
{
    private inventarioPrueba invenPrueba;
    public GameObject itemButtom;
    private GameObject jugador;
    [SerializeField] GameObject linterna;

    private int precio;
    private int totalHuesos;
    private int valorPocionStamina = 1;
    private int valorEscudo = 2;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        invenPrueba = jugador.GetComponent<inventarioPrueba>();
    }

    public void PrecioObjeto(string objeto)
    {
        switch (objeto)
        {
            case "BotonStamina":
                precio = 1;
                break;
            case "BotonEscudo":
                precio = 2;
                break;
        }
    }
    public void AdquirirObjeto(string objeto)
    {
        PrecioObjeto(objeto);
        itemButtom = (GameObject)Resources.Load(objeto); 
        for (int i = 0; i < invenPrueba.slots.Length; i++)
        {
            if (invenPrueba.isFull[i] == null && precio <= GameManager.Instance.PuntosTotales)
            {
                totalHuesos = GameManager.Instance.PuntosTotales;
                GameManager.Instance.RestarPuntos(precio);
                invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
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
                if (invenPrueba.isFull[i] == null)
                {
                    invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleA")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == null)
                {
                    invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleS")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == null)
                {
                    invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "linterna")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == null)
                {
                    GameObject boton = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    boton.GetComponent<Linterna>().slot = i;
                    GameObject linternaArma = Instantiate(linterna,Vector3.zero,Quaternion.identity,jugador.transform);
                    linternaArma.transform.localPosition = Vector3.zero;
                    linternaArma.SetActive(false);
                    invenPrueba.isFull[i] = linternaArma;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
