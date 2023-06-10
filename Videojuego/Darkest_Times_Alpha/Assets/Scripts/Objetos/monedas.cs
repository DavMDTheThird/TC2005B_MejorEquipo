using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class monedas : MonoBehaviour
{
    public TextMeshProUGUI CantidadHuesos;


    // Update is called once per frame
    void Update()
    {
        CantidadHuesos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        CantidadHuesos.text = puntosTotales.ToString();
    }
}
