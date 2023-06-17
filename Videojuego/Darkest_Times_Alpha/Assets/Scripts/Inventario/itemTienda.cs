using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTienda : MonoBehaviour
{
    
    private inventarioPrueba invenPrueba;
    private GameObject jugador;
    private GameObject inventario;

    private void Start()
    {
         jugador = GameObject.FindGameObjectWithTag("Player");
    if (jugador != null)
    {
        Transform inventarioTransform = jugador.transform.GetChild(1);
        if (inventarioTransform != null)
        {
            inventario = inventarioTransform.gameObject;
        }
    }
        invenPrueba = jugador.GetComponent<inventarioPrueba>();
    }

    // Start is called before the first frame update
    public void comprarObjeto()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        invenPrueba = jugador.GetComponent<inventarioPrueba>();
        for (int i = 0; i < invenPrueba.slots.Length; i++)
        {
            if (invenPrueba.isFull[i] == null)
            {
                invenPrueba.isFull[i] = Instantiate(inventario, invenPrueba.slots[i].transform, false);
                break;
            }
        }
    }
}