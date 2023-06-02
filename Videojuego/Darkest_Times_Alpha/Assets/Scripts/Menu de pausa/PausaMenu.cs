using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Hueso;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Hueso.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Hueso.SetActive(true);
        Time.timeScale = 1;
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
