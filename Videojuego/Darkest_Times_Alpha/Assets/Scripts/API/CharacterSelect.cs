using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.Networking;


[System.Serializable]
public class StartCharacter
{
    public short _hp;
    public short _maxhp;
    public short _lvl;
    public short _xp;
    public short _lck;
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


public class CharacterSelect : MonoBehaviour
{
    [SerializeField] string url_stCharacter;
    [SerializeField] string getUsersEP_stCharacter;
    [SerializeField] Text errorText_stCharacter;

    [SerializeField] string url_stCheckpoint;
    [SerializeField] string getUsersEP_stCheckpoint;
    [SerializeField] Text errorText_stCheckpoint;

    public Response respuesta_para_ID_personaje;

    public Response respuesta_para_ID_checkpoint;



    public void InsertDAVID()
    {
        StartCoroutine(StartCharacterDAVID());
    }
    //public void InsertJUANPA()
    //{
    //    StartCoroutine(StartCharacterJUANPA());
    //}
    //public void InsertANGEL()
    //{
    //    StartCoroutine(StartCharacterANGEL());
    //}
    //public void InsertDANI()
    //{
    //    StartCoroutine(StartCharacterDANI());
    //}


    IEnumerator StartCharacterDAVID()
    {
        // Create the object to be sent as json
        StartCharacter stCharacter = new StartCharacter();

        stCharacter._hp = 0;
        stCharacter._maxhp = 0;
        stCharacter._lvl = 0;
        stCharacter._xp = 0;
        stCharacter._lck = 0;
        stCharacter._atk = 0;
        stCharacter._stamina = 0;
        stCharacter._inventory = 0;
        stCharacter._TimesMoney = 0;
        stCharacter._money = 0;


        string jsonData = JsonUtility.ToJson(stCharacter);

        Debug.Log(url_stCharacter + getUsersEP_stCharacter);
        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url_stCharacter + getUsersEP_stCharacter, jsonData))
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

        StartCoroutine(AddCheckpoint());
    }




    IEnumerator AddCheckpoint()
    {

        // Create the object to be sent as json
        CreateCheckpoint testUser = new CreateCheckpoint();

        testUser.id_usuario = 5;
        testUser.id_personaje = PlayerPrefs.GetInt("id_personaje");
        testUser.id_inventario = 0;
        testUser.id_nivel = 0;


        string jsonData = JsonUtility.ToJson(testUser);

        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url_stCheckpoint + getUsersEP_stCheckpoint, jsonData))
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
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText_stCheckpoint != null) errorText_stCheckpoint.text = "Error: " + www.error;
            }
        }
    }

}
