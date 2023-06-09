using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventarioPrueba : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public GameObject inventario;
    bool inventario_prendido = false;
    public int totalObjetos;

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


