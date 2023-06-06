using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player_stats : MonoBehaviour
{
    //API URI
    [SerializeField] string url;
    [SerializeField] string getUsersEP;
    [SerializeField] Text errorText;

    //Player_basic playerBSC;
    public bool babyCharacter = true;
    Player_basic playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 0);

    void Start()
    {
        /*if (File.Exists(Application.dataPath + "/changeScene.json"))
        {
            Debug.Log("Si existe previa instancia, iniciando player");
            playerBSC = LoadFromJson();
        }
        else
        {
            Debug.Log("No existio previa instancia, ERROR ERROR");
        }*/
    }



    // Testing
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




    // Player interactions
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
    public void QueryCheckpoint()
    {
        StartCoroutine(GetCheckpoint());
    }

    public void InsertNewCheckpoint()
    {
        StartCoroutine(AddCheckpoint());
    }
    IEnumerator GetCheckpoint()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"api\"juego\"checkpoint\":" + www.downloadHandler.text + "}";
                allUsers = JsonUtility.FromJson<UserList>(jsonString);
                //Aqui se realiza la funcionalidad
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }



    // Json Stuff
    public void SaveToJson()
    {
        string json = JsonUtility.ToJson(playerBSC, true);
        // File.WriteAllText(Application.dataPath + "/changeScene.json", json);
        // Debug.Log("Se guardo Exitosamente");
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
