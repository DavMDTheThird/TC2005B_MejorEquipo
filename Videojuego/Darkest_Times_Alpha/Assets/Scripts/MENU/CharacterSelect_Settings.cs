using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CharacterSelect_Settings : MonoBehaviour
{
    public void BackToMainMenu(){
        SceneManager.LoadScene("Menu"); //Nombre o indice de la escena
    }

}
