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
    [SerializeField] GameObject mechero;
    [SerializeField] GameObject antorcha;


    private int precio;
    private int totalHuesos;
    private int valorPocionStamina = 1;
    private int valorEscudo = 2;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        invenPrueba = jugador.GetComponent<inventarioPrueba>();
    }

    // public void PrecioObjeto(string objeto)
    // {
    //     switch (objeto)
    //     {
    //         case "BotonStamina":
    //             precio = 15;
    //             break;
    //         case "BotonEscudo":
    //             precio = 20;
    //             break;
    //         case "BotonAtaque":
    //             precio = 15;
    //             break;
    //         case "BotonVida":
    //             precio = 10;
    //             break;
    //     }
    // }
    public void AdquirirObjeto(string objeto)
    {
        // PrecioObjeto(objeto);
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
        // if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleE")
        // {
        //     jugador = GameObject.FindGameObjectWithTag("Player");
        //     invenPrueba = jugador.GetComponent<inventarioPrueba>();
        //     for (int i = 0; i < invenPrueba.slots.Length; i++)
        //     {
        //         if (invenPrueba.isFull[i] == null)
        //         {
        //             invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
        //             Destroy(gameObject);
        //             break;
        //         }
        //     }
        // }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleA")
        {
            jugador = GameObject.FindGameObjectWithTag("Player");
            invenPrueba = jugador.GetComponent<inventarioPrueba>();
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
        // if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleS")
        // {
        //     jugador = GameObject.FindGameObjectWithTag("Player");
        //     invenPrueba = jugador.GetComponent<inventarioPrueba>();
        //     for (int i = 0; i < invenPrueba.slots.Length; i++)
        //     {
        //         if (invenPrueba.isFull[i] == null)
        //         {
        //             invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
        //             Destroy(gameObject);
        //             break;
        //         }
        //     }
        // }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleV")
        {
            jugador = GameObject.FindGameObjectWithTag("Player");
            invenPrueba = jugador.GetComponent<inventarioPrueba>();
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
        if (collision.CompareTag("Player") && gameObject.tag == "mechero")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == null)
                {
                    GameObject boton = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    boton.GetComponent<Mechero>().slot = i;
                    GameObject mecheroArma = Instantiate(mechero,jugador.transform,false);
                    mecheroArma.transform.localPosition = Vector3.zero;
                    mecheroArma.SetActive(false);
                    invenPrueba.isFull[i] = mecheroArma;
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "antorcha")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == null)
                {
                    GameObject boton = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    boton.GetComponent<Antorcha>().slot = i;
                    GameObject antorchaArma = Instantiate(antorcha,jugador.transform,false);
                    antorchaArma.transform.localPosition = Vector3.zero;
                    antorchaArma.SetActive(false);
                    invenPrueba.isFull[i] = antorchaArma;
                    Destroy(gameObject);
                    break;
                }
            }
        }
        // if (collision.CompareTag("Player") && gameObject.tag == "bengalas")
        // {
        //     for (int i = 0; i < invenPrueba.slots.Length; i++)
        //     {
        //         if (invenPrueba.isFull[i] == null)
        //         {
        //             GameObject boton = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
        //             boton.GetComponent<Bengala>().slot = i;
        //             GameObject bengalaArma = Instantiate(bengala,jugador.transform,false);
        //             bengalaArma.transform.localPosition = Vector3.zero;
        //             bengalaArma.SetActive(false);
        //             invenPrueba.isFull[i] = bengalaArma;
        //             Destroy(gameObject);
        //             break;
        //         }
        //     }
        // }
    }
}
