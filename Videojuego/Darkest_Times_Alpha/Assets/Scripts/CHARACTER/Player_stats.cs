using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


//[System.Serializable]
//public class UserCheckpoint
//{
//    public int ID_usuario;
//    public string nombre;
//    public string correo;
//    public string contraseña;
//}

public class Player_stats : MonoBehaviour
{
    //API
    [SerializeField] string url;
    [SerializeField] string getUsersEP;
    [SerializeField] Text errorText;

    //Player_basic playerBSC;
    public bool babyCharacter = true;
    Player_basic playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 1, 0);
    Player_basic player;

    public List<GameObject> HeartContainer;


    void Start()
    {
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

        QueryUsers();

        ShowHearts();

    }



    // Testing
    void Update()
    {
        if (playerBSC.HP == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
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
        if (Input.GetKeyUp(KeyCode.I))
        {
            QueryUsers();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            playerBSC = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 1, 0);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            ShowHearts();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("ID del usuario: " + PlayerPrefs.GetInt("id_inventario"));
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

    //public void InsertNewUser()
    //{
    //    StartCoroutine(AddUser());
    //}


    IEnumerator GetUserCheckpoint()
    {
        Debug.Log(url + getUsersEP + "{\"id\":" + PlayerPrefs.GetInt("id") + "}");
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP + "{\"id\":" + PlayerPrefs.GetInt("id") + "}"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                //Debug.Log("Response: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                player = JsonUtility.FromJson<Player_basic>(jsonString);
                player.Info();
                if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
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