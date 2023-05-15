using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonMenu;

    public void Pausa()
    {
        Time.timeScale = 0;
        botonPausa.SetActive(false);
        botonMenu.SetActive(true);
    }

    public void Resumir()
    {
        Time.timeScale = 1;
        botonPausa.SetActive(true);
        botonMenu.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

}
