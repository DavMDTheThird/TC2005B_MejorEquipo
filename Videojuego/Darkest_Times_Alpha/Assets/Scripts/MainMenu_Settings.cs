using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu_Settings : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("CharacterSelect"); //Nombre o indice de la escena
    }


    public void QuitGame(){
        Application.Quit();
    }
}
