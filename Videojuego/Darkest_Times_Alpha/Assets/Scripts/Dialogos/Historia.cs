using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Historia : MonoBehaviour
{
    private bool cercaTrigger; //Verifica si el jugador esta en el trigger
    private bool dialogoInicio; //Verifica si el dialogo ya inicio
    private int numeroLinea; //Numero de la linea del parrafo
    private float typingTime = 0.05f; //Velocidad con que sale el texto
    [SerializeField] private GameObject dialogoPanel; //Panel donde se despliega el dialogo
    [SerializeField] private TMP_Text dialogoTexto; //Texto o dialogo
    [SerializeField,TextArea(4,6)] private string[] dialogoLinea; //Numero de parrafos con 4 a 6 lineas 


    // Update is called once per frame
    void Update()
    {
        if(cercaTrigger && Input.GetKeyDown(KeyCode.E)){
            if(!dialogoInicio){
                StartDialogue();
            }else if(dialogoTexto.text == dialogoLinea[numeroLinea]){
                NextDialogueLine();
            }
            else{
                StopAllCoroutines();
                dialogoTexto.text = dialogoLinea[numeroLinea];
            }
        }
    }
   

    private void StartDialogue(){
        dialogoInicio = true;
        dialogoPanel.SetActive(true);
        numeroLinea = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        numeroLinea++;
        if(numeroLinea<dialogoLinea.Length){
            StartCoroutine(ShowLine());
        }
        else{
            dialogoInicio = false;
            dialogoPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine(){
        dialogoTexto.text = string.Empty;
        foreach(char ch in dialogoLinea[numeroLinea]){
            dialogoTexto.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D objeto){
        if(objeto.gameObject.CompareTag("Player")){
            cercaTrigger = true;
            Debug.Log("Se inicia diaologo");
            if(!dialogoInicio){
                StartDialogue();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D objeto){
        if(objeto.gameObject.CompareTag("Player")){
            cercaTrigger = false;
            Debug.Log("No se inicia");
            Destroy(this.gameObject);
        }
    }
}
