using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //  public int PuntosTotales { get { return puntosTotales; } }
    public static GameManager Instance { get; private set; }

    // private int puntosTotales;

    public monedas contador_monedas;

    public int PuntosTotales { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Más de un Game Manager en escena");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales = PuntosTotales + puntosASumar;
        //Debug.Log(PuntosTotales);
        contador_monedas.ActualizarPuntos(PuntosTotales);
    }
    public void RestarPuntos(int puntosARestar)
    {
        PuntosTotales = PuntosTotales - puntosARestar;
        //Debug.Log(PuntosTotales);
        contador_monedas.ActualizarPuntos(PuntosTotales);
    }
}
