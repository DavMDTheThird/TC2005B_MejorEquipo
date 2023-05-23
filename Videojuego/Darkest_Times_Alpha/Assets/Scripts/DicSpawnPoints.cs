using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A lo mejor va a ser mas eficiente si solo agaramos el de abajo (espacio de memoria)
//using System.Collections.Generic;

public class DicSpawnPoints : MonoBehaviour
{
    // Creacion de la lista que contendra como llave el nombre de la scene, y le correspondera
    // un array de arrays, que contendra todos los spawn points de la scene y sus cordenadas en x, y, z respectivamente.
    // ej; "HUB" : {{0, 1, 0}, {1, 0, 0}} El "HUB" tiene dos spawn points posibles.

    //Esto la define como solo lectura y publica para usar en todos lados
    public static DicSpawnPoints Instance { get; private set; }

    public Dictionary<string, float[][]> myDictionary;

    //Lugares con sus respectivas coordenadas
    float[][] prueba_SPs =
    {
        new float[] { 0, 0, 0 },
        new float[] { 3, 3, 0 },
        new float[] { -1, -1, 0 }
    };



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Inicializar el diccionario
        myDictionary = new Dictionary<string, float[][]>();
        // Agreagar todos los puntos al diccionario (complejidad constante O(1))
        myDictionary.Add("prueba", prueba_SPs);
    }
}
