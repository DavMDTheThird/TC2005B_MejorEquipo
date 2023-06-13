using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


[System.Serializable]
public class userStats
{
    public int vida_actual;
    public int vida_max;
    public int nivel;
    public int xp;
    public float suerte;
    public int ataque;
    public int stamina;
    public int inventario;
    public float multiplicador_monedas;
    public int monedas;
}
[System.Serializable]
public class userStatsID
{
    public int vida_actual;
    public int vida_max;
    public int nivel;
    public int xp;
    public float suerte;
    public int ataque;
    public int stamina;
    public int inventario;
    public float multiplicador_monedas;
    public int monedas;
    public int id;

}


public class Player_stats : MonoBehaviour
{
    //API
    [SerializeField] string url;
    [SerializeField] string getUsersEP;
    [SerializeField] Text errorText;

    [SerializeField] string updateCheckpointEP;
    [SerializeField] Text errorText_updateCheckpoint;

    public Response respuesta_para_updateCheckpoint;

    //public bool babyCharacter = true;
    Player_basic playerBSC;
    //Player_basic playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 5, 5, 1, 0);

    public List<GameObject> HeartContainer;


    void Start()
    {
        PlayerPrefs.SetInt("id", 1);
        PlayerPrefs.SetInt("personaje", 1);
        //PlayerPrefs.SetInt("id_inventario", 1);
        //PlayerPrefs.SetInt("id_checkpoint", 1);

        QueryUsers();

        HeartContainer.Add(GameObject.Find("0Hearts"));
        HeartContainer.Add(GameObject.Find("1Hearts"));
        HeartContainer.Add(GameObject.Find("2Hearts"));
        HeartContainer.Add(GameObject.Find("3Hearts"));
        HeartContainer.Add(GameObject.Find("4Hearts"));
        HeartContainer.Add(GameObject.Find("5Hearts"));
        HeartContainer.Add(GameObject.Find("6Hearts"));
        HeartContainer.Add(GameObject.Find("7Hearts"));
        HeartContainer.Add(GameObject.Find("8Hearts"));
        HeartContainer.Add(GameObject.Find("9Hearts"));
        HeartContainer.Add(GameObject.Find("10Hearts"));
    }



    // Testing
    void Update()
    {
        if (playerBSC != null && playerBSC.HP == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            TakeDamage(-1);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            playerBSC.Info();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            GetMoney(10);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            QueryUsers();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 5, 5, 1, 0);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            ShowHearts();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("ID del usuario: " + PlayerPrefs.GetInt("id"));
            Debug.Log("ID del inventario: " + PlayerPrefs.GetInt("id_inventario"));
            Debug.Log("id_checkpoint: " + PlayerPrefs.GetInt("id_checkpoint"));
        }
    }




    // Player interactions
    public void TakeDamage(short damage)
    {
        if (playerBSC.HP - damage <= 0)
        {
            playerBSC.HP = 0;
        }
        else
        {
            playerBSC.HP -= damage;
        }
        ShowHearts();
        //Debug.Log(transform.name + " took: " + damage + " damage. HP now: " + playerBSC.HP);
    }

    public void GetMoney(short money)
    {
        playerBSC.Money += money;
        Debug.Log(transform.name + " gain: " + money + " money. Total money now: " + playerBSC.Money);
    }

    public void ShowHearts()
    {
        Debug.Log(playerBSC.HP);
        short i = 0;
        foreach (GameObject obj in HeartContainer)
        {
            obj.SetActive(false);

            if(playerBSC.HP == i)
            {
                obj.SetActive(true);
            }
            ++i;
        }

    }




    // Json Stuff
    public void QueryUsers()
    {
        StartCoroutine(GetUserCheckpoint());
    }

    public void PutCheckpoint()
    {
        StartCoroutine(UpdateCheckpoint());
    }


    IEnumerator GetUserCheckpoint()
    {
        //Debug.Log(url + getUsersEP + "{\"id\":" + PlayerPrefs.GetInt("id") + "}");
        //using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP + "{\"id\":" + PlayerPrefs.GetInt("id") + "}"))

        string requestUrl = url + getUsersEP + "/" + PlayerPrefs.GetInt("id").ToString();

        Debug.Log(requestUrl);

        using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                //Debug.Log("Response: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                userStats playerSTATS;
                playerSTATS = JsonUtility.FromJson<userStats>(jsonString);
                Debug.Log(jsonString);

                playerBSC = new Player_basic(playerSTATS.vida_actual, playerSTATS.vida_max, playerSTATS.nivel, playerSTATS.xp, playerSTATS.suerte, playerSTATS.ataque, playerSTATS.stamina, playerSTATS.inventario, playerSTATS.multiplicador_monedas, playerSTATS.monedas);

                playerBSC.Info();
                if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
        ShowHearts();
    }


    IEnumerator UpdateCheckpoint()
    {
        userStatsID User = new userStatsID();

        User.vida_actual = playerBSC.HP;
        User.vida_max = playerBSC.MAXHP;
        User.nivel = 1;
        User.xp = playerBSC.XP;
        User.suerte = playerBSC.LCK;
        User.ataque = playerBSC.ATK;
        User.stamina = playerBSC.Stamina;
        User.inventario = playerBSC.Inventory;
        User.multiplicador_monedas = playerBSC.TimesMoney;
        User.monedas = playerBSC.Money;
        User.id = PlayerPrefs.GetInt("id");


        string jsonData = JsonUtility.ToJson(User);

        //Debug.Log(url + EP_stCheckpoint);
        Debug.Log(jsonData);


        using (UnityWebRequest www = UnityWebRequest.Put(url + updateCheckpointEP, jsonData))
        {
            //www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_updateCheckpoint = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_updateCheckpoint != null) errorText_updateCheckpoint.text = "";

                //PlayerPrefs.SetInt("id_checkpoint", respuesta_para_ID_checkpoint.id);
                //Debug.Log("id_checkpoint: " + PlayerPrefs.GetInt("id_checkpoint"));
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_updateCheckpoint != null) errorText_updateCheckpoint.text = "Error: " + www.error;
            }


            Debug.Log("HOLA");
        }
    }




    //IEnumerator AddUser()
    //{
    //    /*
    //    // This should work with an API that does NOT expect JSON
    //    WWWForm form = new WWWForm();
    //    form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
    //    form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
    //    Debug.Log(form);
    //    */

    //    // Create the object to be sent as json
    //    User testUser = new User();
    //    testUser.name = "newGuy" + Random.Range(1000, 9000).ToString();
    //    testUser.surname = "Tester" + Random.Range(1000, 9000).ToString();
    //    //Debug.Log("USER: " + testUser);
    //    string jsonData = JsonUtility.ToJson(testUser);
    //    //Debug.Log("BODY: " + jsonData);

    //    // Send using the Put method:
    //    // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
    //    using (UnityWebRequest www = UnityWebRequest.Put(url + getUsersEP, jsonData))
    //    {
    //        //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
    //        // Set the method later, and indicate the encoding is JSON
    //        //www.method = "POST";
    //        www.SetRequestHeader("Content-Type", "application/json");
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Response: " + www.downloadHandler.text);
    //            //if (errorText != null) errorText.text = "";
    //        }
    //        else
    //        {
    //            Debug.Log("Error: " + www.error);
    //            //if (errorText != null) errorText.text = "Error: " + www.error;
    //        }
    //    }
    //}


}