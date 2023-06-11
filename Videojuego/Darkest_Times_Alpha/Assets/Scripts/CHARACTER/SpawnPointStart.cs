using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnPointStart : MonoBehaviour
{
    public GameObject player_prefab1;
    public GameObject player_prefab2;
    public GameObject player_prefab3;
    public GameObject player_prefab4;
    public GameObject player_prefab;


    // public Vector3 position = new Vector3(0f, 0f, 0f);
    public short id_spwnPoint = 0;
    private Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);


    void Start()
    {
        Debug.Log("Personaje: " + PlayerPrefs.GetInt("personaje"));
        // Get the currently active scene and Get the name of the active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Accesar el diccionario con los spawn points del scene
        float[][] spwnPoints = DicSpawnPoints.Instance.myDictionary[currentScene.name];
        // Cambiar el array de spawn points a solo el que queremos en un Vector3
        Vector3 spwnPoint = new Vector3(spwnPoints[id_spwnPoint][0], spwnPoints[id_spwnPoint][1], spwnPoints[id_spwnPoint][2]);


        // Poner el jugador en el spawn correcto al inicio
        if (PlayerPrefs.GetInt("personaje") == 1)
        {
            Instantiate(player_prefab1, spwnPoint, rotation);
        }
        else if (PlayerPrefs.GetInt("personaje") == 2)
        {
            Instantiate(player_prefab2, spwnPoint, rotation);
        }
        else if (PlayerPrefs.GetInt("personaje") == 3)
        {
            Instantiate(player_prefab3, spwnPoint, rotation);
        }
        else if (PlayerPrefs.GetInt("personaje") == 4)
        {
            Instantiate(player_prefab4, spwnPoint, rotation);
        }
        else
        {
            Instantiate(player_prefab, spwnPoint, rotation);
        }
    }
}
