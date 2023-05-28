using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumirPocion : MonoBehaviour
{
    [SerializeField] ObjetosPociones objetosPocions;

    public enum ObjetosPociones
    {
        Stamina,
        Velocidad,
        Ataque
    };

    public void UsarObjetos()
    {
        switch(objetosPocions)
        {
            case ObjetosPociones.Stamina:
                Debug.Log("Consumir pocion stamina");
                break;
            case ObjetosPociones.Velocidad:
                Debug.Log("Consumir pocion velocidad");
                break;
            case ObjetosPociones.Ataque:
                Debug.Log("Consumir pocion ataque");
                break;
        }

        Destroy(this.gameObject);
    }
}
