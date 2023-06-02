using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class monedas : MonoBehaviour
{
    public TextMeshProUGUI Puntos;

    // Update is called once per frame
    void Update()
    {
        Puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        Puntos.text = puntosTotales.ToString();
    }
}
