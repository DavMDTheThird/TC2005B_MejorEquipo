using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



[System.Serializable]
public class StartCharacter
{
    public short personaje;
    public short _hp;
    public short _maxhp;
    public short _lvl;
    public short _xp;
    public float _lck;
    public short _atk;
    public short _stamina;
    public short _inventory;
    public float _TimesMoney;
    public short _money;
}
[System.Serializable]
public class CreateCheckpoint
{
    public int id_usuario;
    public int id_personaje;
    public int id_inventario;
    public int id_nivel;
}
[System.Serializable]
public class CreateInventory
{
    public short pocionQM;
    public short escudoQM;
    public short antorchaQM;
    public short linternaQM;
    public short mecheroQM;
    public short bengala_gunQM;
    public bool ballesta;
    public bool espada;
    public bool bat;
    public bool staff;
    public bool rifle;
}





public class CharacterSelect : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string EP_stCharacter;
    [SerializeField] Text errorText_stCharacter;


    [SerializeField] string EP_stInventory;
    [SerializeField] Text errorText_stInventory;

    [SerializeField] string EP_stCheckpoint;
    [SerializeField] Text errorText_stCheckpoint;

    public Response respuesta_para_ID_personaje;
    public Response respuesta_para_ID_checkpoint;
    public Response respuesta_para_ID_inventario;


    public void InsertDAVID()
    {
        StartCoroutine(StartCharacterDAVID());
    }
    public void InsertJUANPA()
    {
        StartCoroutine(StartCharacterJUANPA());
    }
    public void InsertANGEL()
    {
        StartCoroutine(StartCharacterANGEL());
    }
    public void InsertDANI()
    {
        StartCoroutine(StartCharacterDANI());
    }


    IEnumerator StartCharacterDAVID()
    {
        // Create the object to be sent as json
        StartCharacter stCharacter = new StartCharacter();

        stCharacter.personaje = 1;
        stCharacter._hp = 8;
        stCharacter._maxhp = 8;
        stCharacter._lvl = 0;
        stCharacter._xp = 0;
        stCharacter._lck = .85F;
        stCharacter._atk = 5;
        stCharacter._stamina = 3;
        stCharacter._inventory = 5;
        stCharacter._TimesMoney = 1F;
        stCharacter._money = 0;


        string jsonData = JsonUtility.ToJson(stCharacter);

        Debug.Log(url + EP_stCharacter);
        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url + EP_stCharacter, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID_personaje = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_stCharacter != null) errorText_stCharacter.text = "";

                PlayerPrefs.SetInt("id_personaje", respuesta_para_ID_personaje.id);
                Debug.Log("id_personaje: " + PlayerPrefs.GetInt("id_personaje"));


            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCharacter != null) errorText_stCharacter.text = "Error: " + www.error;
            }
        }

        PlayerPrefs.SetInt("personaje", 1);
        yield return StartCoroutine(AddInventario(1));
        yield return StartCoroutine(AddCheckpoint());

        SceneManager.LoadScene("Lobby");
    }

    IEnumerator StartCharacterJUANPA()
    {
        // Create the object to be sent as json
        StartCharacter stCharacter = new StartCharacter();

        stCharacter.personaje = 1;
        stCharacter._hp = 6;
        stCharacter._maxhp = 6;
        stCharacter._lvl = 0;
        stCharacter._xp = 0;
        stCharacter._lck = 0.8F;
        stCharacter._atk = 4;
        stCharacter._stamina = 4;
        stCharacter._inventory = 5;
        stCharacter._TimesMoney = 1.5F;
        stCharacter._money = 0;


        string jsonData = JsonUtility.ToJson(stCharacter);

        Debug.Log(url + EP_stCharacter);
        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url + EP_stCharacter, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID_personaje = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_stCharacter != null) errorText_stCharacter.text = "";

                PlayerPrefs.SetInt("id_personaje", respuesta_para_ID_personaje.id);
                Debug.Log("id_personaje: " + PlayerPrefs.GetInt("id_personaje"));


            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCharacter != null) errorText_stCharacter.text = "Error: " + www.error;
            }
        }

        PlayerPrefs.SetInt("personaje", 2);
        yield return StartCoroutine(AddInventario(2));
        yield return StartCoroutine(AddCheckpoint());

        SceneManager.LoadScene("Lobby");
    }

    IEnumerator StartCharacterANGEL()
    {
        // Create the object to be sent as json
        StartCharacter stCharacter = new StartCharacter();

        stCharacter.personaje = 1;
        stCharacter._hp = 6;
        stCharacter._maxhp = 6;
        stCharacter._lvl = 0;
        stCharacter._xp = 0;
        stCharacter._lck = 0.5F;
        stCharacter._atk = 5;
        stCharacter._stamina = 5;
        stCharacter._inventory = 5;
        stCharacter._TimesMoney = 2F;
        stCharacter._money = 10;


        string jsonData = JsonUtility.ToJson(stCharacter);

        Debug.Log(url + EP_stCharacter);
        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url + EP_stCharacter, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID_personaje = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_stCharacter != null) errorText_stCharacter.text = "";

                PlayerPrefs.SetInt("id_personaje", respuesta_para_ID_personaje.id);
                Debug.Log("id_personaje: " + PlayerPrefs.GetInt("id_personaje"));


            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCharacter != null) errorText_stCharacter.text = "Error: " + www.error;
            }
        }

        PlayerPrefs.SetInt("personaje", 3);
        yield return StartCoroutine(AddInventario(3));
        yield return StartCoroutine(AddCheckpoint());

        SceneManager.LoadScene("Lobby");
    }

    IEnumerator StartCharacterDANI()
    {
        // Create the object to be sent as json
        StartCharacter stCharacter = new StartCharacter();

        stCharacter.personaje = 1;
        stCharacter._hp = 8;
        stCharacter._maxhp = 8;
        stCharacter._lvl = 0;
        stCharacter._xp = 0;
        stCharacter._lck = 0.85F;
        stCharacter._atk = 4;
        stCharacter._stamina = 3;
        stCharacter._inventory = 5;
        stCharacter._TimesMoney = 1F;
        stCharacter._money = 0;


        string jsonData = JsonUtility.ToJson(stCharacter);

        Debug.Log(url + EP_stCharacter);
        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url + EP_stCharacter, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID_personaje = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_stCharacter != null) errorText_stCharacter.text = "";

                PlayerPrefs.SetInt("id_personaje", respuesta_para_ID_personaje.id);
                Debug.Log("id_personaje: " + PlayerPrefs.GetInt("id_personaje"));


            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCharacter != null) errorText_stCharacter.text = "Error: " + www.error;
            }
        }

        PlayerPrefs.SetInt("personaje", 4);
        yield return StartCoroutine(AddInventario(4));
        yield return StartCoroutine(AddCheckpoint());

        SceneManager.LoadScene("Lobby");
    }





    private CreateInventory chooseCharacter(short character)
    {
            CreateInventory stInventory = new CreateInventory();
            stInventory.pocionQM = 0;
            stInventory.escudoQM = 0;
            stInventory.antorchaQM = 0;
            stInventory.linternaQM = 0;
            stInventory.mecheroQM = 0;
            stInventory.bengala_gunQM = 0;
            stInventory.rifle = false;
        if(character == 1)
        {
            stInventory.ballesta = true;
            stInventory.espada = false;
            stInventory.bat = false;
            stInventory.staff = false;
        }
        else if (character == 2)
        {
            stInventory.ballesta = false;
            stInventory.espada = true;
            stInventory.bat = false;
            stInventory.staff = false;
        }
        else if (character == 3)
        {
            stInventory.ballesta = false;
            stInventory.espada = false;
            stInventory.bat = true;
            stInventory.staff = false;
        }
        else if (character == 4)
        {
            stInventory.ballesta = false;
            stInventory.espada = false;
            stInventory.bat = false;
            stInventory.staff = true;
        }

        return stInventory;
    }




    IEnumerator AddInventario(short num)
    {
        CreateInventory stInventory = chooseCharacter(num);


        string jsonData = JsonUtility.ToJson(stInventory);

        Debug.Log(url + EP_stInventory);
        Debug.Log(jsonData);


        using (UnityWebRequest www = UnityWebRequest.Put(url + EP_stInventory, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID_inventario = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_stCheckpoint != null) errorText_stCheckpoint.text = "";

                PlayerPrefs.SetInt("id_inventario", respuesta_para_ID_inventario.id);
                Debug.Log("id_inventario: " + PlayerPrefs.GetInt("id_inventario"));
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCheckpoint != null) errorText_stCheckpoint.text = "Error: " + www.error;
            }
        }
    }







    IEnumerator AddCheckpoint()
    {
        CreateCheckpoint testUser = new CreateCheckpoint();

        testUser.id_usuario = PlayerPrefs.GetInt("id");
        testUser.id_personaje = PlayerPrefs.GetInt("id_personaje");
        testUser.id_inventario = PlayerPrefs.GetInt("id_inventario");
        testUser.id_nivel = 5;


        string jsonData = JsonUtility.ToJson(testUser);

        //Debug.Log(url + EP_stCheckpoint);
        Debug.Log(jsonData);


        using (UnityWebRequest www = UnityWebRequest.Put(url + EP_stCheckpoint, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID_checkpoint = JsonUtility.FromJson<Response>(responseJson);

                if (errorText_stCheckpoint != null) errorText_stCheckpoint.text = "";

                PlayerPrefs.SetInt("id_checkpoint", respuesta_para_ID_checkpoint.id);
                Debug.Log("id_checkpoint: " + PlayerPrefs.GetInt("id_checkpoint"));
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCheckpoint != null) errorText_stCheckpoint.text = "Error: " + www.error;
            }
        }
    }

}
