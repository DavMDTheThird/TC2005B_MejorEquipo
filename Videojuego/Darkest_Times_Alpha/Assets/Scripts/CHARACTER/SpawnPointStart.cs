using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointStart : MonoBehaviour
{
    public GameObject player_prefab;
    // public Vector3 position = new Vector3(0f, 0f, 0f);
    public short id_spwnPoint = 0;
    private Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);


    void Start()
    {
        // Accesar el diccionario con los spawn points del scene
        float[][] spwnPoints = DicSpawnPoints.Instance.myDictionary["prueba"];
        // Cambiar el array de spawn points a solo el que queremos en un Vector3
        Vector3 spwnPoint = new Vector3(spwnPoints[id_spwnPoint][0], spwnPoints[id_spwnPoint][1], spwnPoints[id_spwnPoint][2]);


        // Poner el jugador en el spawn correcto al inicio
        GameObject player = Instantiate(player_prefab, spwnPoint, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
