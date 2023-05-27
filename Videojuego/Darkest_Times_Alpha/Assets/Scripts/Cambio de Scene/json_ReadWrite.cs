using UnityEngine;
using System.IO;

public class json_ReadWrite : MonoBehaviour
{
    public GameObject[] player;
    

    public void SaveToJson()
    {
        //Busca al tag: Player y los pone en este array (solo debe de haber solo un personaje con este tag)
        player = GameObject.FindGameObjectsWithTag("Player");

        string json = JsonUtility.ToJson(player[0].GetComponent<Player_basic>(), true);
        File.WriteAllText(Application.dataPath + "/changeScene.json", json);
        Debug.Log("Se guardo Exitosamente");
    }

    public Player_basic LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/changeScene.json");
        Player_basic player = JsonUtility.FromJson<Player_basic>(json);
        
        return player;
    }
}
