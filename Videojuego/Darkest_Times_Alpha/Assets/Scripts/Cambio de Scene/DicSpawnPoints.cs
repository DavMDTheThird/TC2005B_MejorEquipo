using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicSpawnPoints : MonoBehaviour
{
    // Creacion de la lista que contendra como llave el nombre de la scene, y le correspondera
    // un array de arrays, que contendra todos los spawn points de la scene y sus cordenadas en x, y, z respectivamente.
    // ej; "HUB" : {{0, 1, 0}, {1, 0, 0}} El "HUB" tiene dos spawn points posibles.

    //Esto la define como solo lectura y publica para usar en todos lados
    public static DicSpawnPoints Instance { get; private set; }

    public Dictionary<string, float[][]> myDictionary;

    //Scene con sus respectivas coordenadas
    float[][] Prueba_NPC_HUB =
    {
        new float[] { 0, 0, 0 },
        new float[] { 0, 4, 0 },
        new float[] { 7, 0, 0 }
    };
    float[][] Prueba_transision_1 =
    {
        new float[] { 0, 0, 0 },
        new float[] { 0, -4, 0 },
        new float[] { 7, 0, 0 }
    };
    float[][] Prueba_transision_2 =
    {
        new float[] { 0, 0, 0 },
        new float[] { 0, -4, 0 },
        new float[] { -7, 0, 0 }
        
    };
    float[][] Prueba_transision_3 =
    {
        new float[] { 0, 0, 0 },
        new float[] { 0, 4, 0 },
        new float[] { -7, 0, 0 }
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
        myDictionary.Add("Prueba_NPC_HUB", Prueba_NPC_HUB);
        myDictionary.Add("Prueba_transision_1", Prueba_transision_1);
        myDictionary.Add("Prueba_transision_2", Prueba_transision_2);
        myDictionary.Add("Prueba_transision_3", Prueba_transision_3);
    }
}
