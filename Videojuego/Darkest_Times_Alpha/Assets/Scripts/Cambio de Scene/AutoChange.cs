using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AutoChange : MonoBehaviour
{   
    private ScenesGame cambio;
    public string nivelCargar;
    public TextMeshProUGUI texto;
    private void Start()
    {
        cambio = new ScenesGame();
        StartCoroutine(IniciarCarga(nivelCargar));
    }

    IEnumerator IniciarCarga(string nivel)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(nivel);
        operacion.allowSceneActivation = false;
        while(!operacion.isDone){
            if(operacion.progress >= 0.9f){
                texto.text = "Presiona C para continuar";
                if(Input.GetKeyDown(KeyCode.C)){
                    operacion.allowSceneActivation = true;
                    cambio.LoadScene(nivelCargar);
                }
            }
            yield return null;
        }
    }
}
