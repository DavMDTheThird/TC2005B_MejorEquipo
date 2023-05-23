using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player_stats : MonoBehaviour
{
    //Player_basic playerBSC;
    public bool babyCharacter = true;
    Player_basic playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 0);

    void Start()
    {
        if (File.Exists(Application.dataPath + "/changeScene.json"))
        {
            Debug.Log("Si existe previa instancia, iniciando player");
            playerBSC = LoadFromJson();
        }
        else
        {
            Debug.Log("No existio previa instancia, ERROR ERROR");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            playerBSC.Info();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            GetMoney(10);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            SaveToJson();
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            LoadFromJson();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 0);
        }
    }

    public void TakeDamage(short damage)
    {
        playerBSC.HP -= damage;
        Debug.Log(transform.name + " took: " + damage + " damage. HP now: " + playerBSC.HP);
    }

    public void GetMoney(short money)
    {
        playerBSC.Money += money;
        Debug.Log(transform.name + " gain: " + money + " money. Total money now: " + playerBSC.Money);
    }

    public void SaveToJson()
    {
        string json = JsonUtility.ToJson(playerBSC, true);
        File.WriteAllText(Application.dataPath + "/changeScene.json", json);
        Debug.Log("Se guardo Exitosamente");
    }

    public Player_basic LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/changeScene.json");
        Player_basic player = JsonUtility.FromJson<Player_basic>(json);

        Debug.Log("Se cargo Exitosamente");
        //playerBSC.Info();
        return player;
    }


}
