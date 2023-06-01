using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuertas2 : MonoBehaviour
{
    [Header("Icono")]
    [SerializeField] private GameObject MarcaDialogo;
    [Header("Sonido")]
    public EfectosSonido efectoaudio;
    [Header("Animacio y Accion")]
    private Animator animator;
    public bool JugadorCerca;
    public bool Abierta;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.E))
    {
        if (JugadorCerca)
        {
            if (Abierta)
            {
                animator.SetBool("Abrir", false);
                animator.SetBool("Cerrar",true);
                GetComponent<BoxCollider2D>().enabled = true;
                Abierta = false;
            }
            else
            {
                animator.SetBool("Abrir", true);
                animator.SetBool("Cerrar",false);
                GetComponent<BoxCollider2D>().enabled = false;
                Abierta = true;
            }
            
            efectoaudio.GetComponent<AudioSource>().PlayOneShot(efectoaudio.sonido1);
            MarcaDialogo.SetActive(false);
        }
    }
    }


    private void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.CompareTag("Player"))
        {
            JugadorCerca = true;
            MarcaDialogo.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            JugadorCerca = false;
            MarcaDialogo.SetActive(false);
        }
    }

}