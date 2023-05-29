using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaNPC : MonoBehaviour
{
    public GameObject panelDialogo;
    public Text dialogoTxt;
    public string[] dialogo;
    private int index;

    public GameObject contBtn;
    public float velocidadTxt;
    public bool jugadorCerca;

    [SerializeField] private GameObject MarcaDialogo;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && jugadorCerca)
        {
            if(panelDialogo.activeInHierarchy)
            {
                noTxt();
            }
            else
            {
                panelDialogo.SetActive(true);
                StartCoroutine(Escribiendo());
                MarcaDialogo.SetActive(false);
            }
        }
        if(dialogoTxt.text == dialogo[index])
        {
            contBtn.SetActive(true);
        }
    }

    IEnumerator Escribiendo()
    {
        foreach (char letter in dialogo[index].ToCharArray())
        {
            dialogoTxt.text += letter;
            yield return new WaitForSeconds(velocidadTxt);
        }
    }

    public void lineaSiguiente()
    {
        contBtn.SetActive(false);
        if(index < dialogo.Length -1)
        {
            index++;
            dialogoTxt.text = "";
            StartCoroutine(Escribiendo());
        }
        else
        {
            noTxt();
        }
    }

    public void noTxt()
    {
        dialogoTxt.text = "";
        index = 0;
        panelDialogo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            jugadorCerca = true;
            MarcaDialogo.SetActive(true);
            Debug.Log(collision.tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            jugadorCerca = false;
            noTxt();
            MarcaDialogo.SetActive(false);
        }
    }
}
