using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class User
{
    public string nombre;
    public string correo;
    public string contraseña;
}
[System.Serializable]
public class Response
{
    public string mensaje;
    public int id;
}

public class SignIn : MonoBehaviour
{   

    [SerializeField] string url_signIn;
    [SerializeField] string getUsersEP_signIn;
    [SerializeField] Text errorText_signIn;

    [SerializeField] string url_logIn;
    [SerializeField] string getUsersEP_logIn;
    [SerializeField] Text errorText_logIn;

    [SerializeField] string nombre;
    [SerializeField] string correo;
    [SerializeField] string contraseña;

    public Response respuesta_para_ID;
    
    public TMP_Text hi_box;

    public void SetName(){
        hi_box.text = hi_box.text + nombre;
    }



    public void SetInputText_nombre(string input_text){
        Debug.Log("Se guardo: " + input_text);
        nombre = input_text;
    }
    public void SetInputText_correo(string input_text){
        Debug.Log("Se guardo: " + input_text);
        correo = input_text;
    }
    public void SetInputText_contrasenia(string input_text){
        Debug.Log("Se guardo: " + input_text);
        contraseña = input_text;
    }

    public void InsertNewUser()
    {
        StartCoroutine(AddUser());
    }
    // public void SetID{

    // }

    IEnumerator AddUser()
    {
        
        // Create the object to be sent as json
        User testUser = new User();

        // if(length(userNameField.text > 45))
        testUser.nombre = nombre;
        testUser.correo = correo;
        testUser.contraseña = contraseña;
        
        
        string jsonData = JsonUtility.ToJson(testUser);
       
        // Debug.Log(url_signIn + getUsersEP_signIn);
        // Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url_signIn + getUsersEP_signIn, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                string responseJson = www.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                respuesta_para_ID = JsonUtility.FromJson<Response>(responseJson);
                
                if (errorText_signIn != null) errorText_signIn.text = "";
                
                PlayerPrefs.SetString("username", nombre);
                PlayerPrefs.SetInt("id", respuesta_para_ID.id);
            } 
            else {
                Debug.Log("Error: " + www.error);
                if (errorText_signIn != null) errorText_signIn.text = "Error: " + www.error;
            }
        }
    }
}
