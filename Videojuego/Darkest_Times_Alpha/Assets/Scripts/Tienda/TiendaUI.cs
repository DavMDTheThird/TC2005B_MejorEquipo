using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaUI : MonoBehaviour
{
    [SerializeField] private GameObject panelEquipo;

    private int totalMonedas;
    public int totalObjetos;
    private int precioObjeto;

    


    public void AdquirirObjeto(string objeto)
    {
        /*PrecioObjeto(objeto);*/
        /*totalMonedas = gamemaneger.PuntosTotales;*/
        /*
        if (precioObjeto <= totalMonedas && totalObjetos < 5)
        {
            totalObjetos++;
            /*totalMonedas -= precioObjeto;
            
            totalMonedas -= precioObjeto;
        }*/
        if(totalObjetos < 5)
        {
            totalObjetos++;
            GameObject equipo = (GameObject)Resources.Load(objeto); // va dentro del if
            Instantiate(equipo, Vector3.zero, Quaternion.identity, panelEquipo.transform); // va dentro del if
            
        }
        

    }

    public void PrecioObjeto(string objeto)
    {
        switch(objeto)
        {
            case "PocionStaminaBtn":
                precioObjeto = 1;
                break;
            case "EscudoBtn":
                precioObjeto = 2;
                break;
        }
    }
}
