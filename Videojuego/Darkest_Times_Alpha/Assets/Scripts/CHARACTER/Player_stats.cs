using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player_stats : MonoBehaviour
{
    Player_basic player;
    json_ReadWrite json;

    void Start()
    {
        player = new Player_basic();
        json = new json_ReadWrite();

        if (File.Exists(Application.dataPath + "/changeScene.json"))
        {
            Debug.Log("Si existe previa instancia, iniciando player");
            player = json.LoadFromJson();
        }
        else
        {
            Debug.Log("No existio previa instancia, iniciando player inicial");
            //Aqui van los datos iniciales con los que iniciara el personaje
            player = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 0);
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
            Debug.Log("A: " + player.name); 
            player.Info();
            Debug.Log("B");
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            GetMoney(10);
        }
    }

    public void TakeDamage(short damage)
    {
        player.HP -= damage;
        Debug.Log(transform.name + " took: " + damage + " damage. HP now: " + player.HP);
    }

    public void GetMoney(short money)
    {
        player.Money += money;
        Debug.Log(transform.name + " gain: " + money + " money. Total money now: " + player.Money);
    }


}
