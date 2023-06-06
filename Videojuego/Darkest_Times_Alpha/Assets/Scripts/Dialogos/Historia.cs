using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Historia : MonoBehaviour
{
    private bool cercaTrigger;
    private bool dialogoInicio;
    private int numeroLinea;
    private float typingTime = 0.05f;
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoTexto;
    [SerializeField,TextArea(4,6)] private string[] dialogoLinea;
    [Header("Icono")]
    [SerializeField] private GameObject MarcaDialogo;

    // Update is called once per frame
    void Update()
    {
        if(cercaTrigger)
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
    }
   

    private void StartDialogue(){
        dialogoInicio = true;
        dialogoPanel.SetActive(true);
        MarcaDialogo.SetActive(false);
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
            MarcaDialogo.SetActive(true);
            Debug.Log("Se inicia diaologo");
        }
        
    }

    private void OnTriggerExit2D(Collider2D objeto){
        if(objeto.gameObject.CompareTag("Player")){
            cercaTrigger = false;
            MarcaDialogo.SetActive(false);
            Debug.Log("No se inicia");
        }
    }
}
