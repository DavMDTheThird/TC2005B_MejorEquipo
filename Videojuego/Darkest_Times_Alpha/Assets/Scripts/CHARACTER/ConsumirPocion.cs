using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumirPocion : MonoBehaviour
{
    [SerializeField] ObjetosPociones objetosPocions;

    public enum ObjetosPociones
    {
        Stamina,
        Vida,
        Ataque,
        Escudo
    };

    public void UsarObjetos()
    {
        switch(objetosPocions)
        {
            case ObjetosPociones.Stamina:
                Debug.Log("Consumir pocion stamina");
                break;
            case ObjetosPociones.Vida:
                Debug.Log("Consumir pocion vida");
                break;
            case ObjetosPociones.Ataque:
                Debug.Log("Consumir pocion ataque");
                break;
            case ObjetosPociones.Escudo:
                Debug.Log("Consumir escudo");
                break;
        }

        Destroy(this.gameObject);
    }
}
