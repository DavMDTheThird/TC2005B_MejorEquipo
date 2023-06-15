using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventarioPrueba : MonoBehaviour
{
    public GameObject[] isFull;
    public GameObject[] slots;

    private GameObject jugador;
    public GameObject inventario;
    bool inventario_prendido = false;
    public int totalObjetos;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        inventario = jugador.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventario_prendido == false)
        {
            inventario.SetActive(true);
            inventario_prendido = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventario_prendido == true)
        {
            inventario.SetActive(false);
            inventario_prendido = false;
        }

    }

}


