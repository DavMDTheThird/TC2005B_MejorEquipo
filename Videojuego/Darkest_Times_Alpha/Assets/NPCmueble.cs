using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCmueble : MonoBehaviour
{
    public GameObject PanelDialogo;
    public Text TextoDialogo;
    public string[] dialogo;
    private int index;
    public float velocidadTexto;
    public bool JugadorCerca;
    public GameObject BotonCont;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.CompareTag("Player"))
        {
            JugadorCerca = true;

        }
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            JugadorCerca = false;
            noTexto();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && JugadorCerca)
        {
            if(PanelDialogo.activeInHierarchy)
            {
                noTexto();
            }
            else
            {
                PanelDialogo.SetActive(true);
                StartCoroutine(Escribiendo());
            }
        }

        if(TextoDialogo.text == dialogo[index])
        {
            BotonCont.SetActive(true);
        }
    }

    public void noTexto()
    {
        TextoDialogo.text = "";
        index = 0;
        PanelDialogo.SetActive(false);
    }

    IEnumerator Escribiendo()
    {
        foreach(char letter in dialogo[index].ToCharArray())
        {
            TextoDialogo.text += letter;
            yield return new WaitForSeconds(velocidadTexto);
        }
    }

    public void LineaSiguiente()
    {
        BotonCont.SetActive(false);

        if(index < dialogo.Length-1)
        {
            index++;
            TextoDialogo.text = "";
            StartCoroutine(Escribiendo());
        }
        else
        {
            noTexto();
        }
    }

}
