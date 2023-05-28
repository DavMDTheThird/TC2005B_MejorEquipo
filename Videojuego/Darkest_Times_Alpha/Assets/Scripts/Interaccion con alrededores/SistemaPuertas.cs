using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuertas : MonoBehaviour
{
    public EfectosSonido efectoaudio;
    [Header("Animacion")]
    private Animator animator;
    public bool JugadorCerca;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && JugadorCerca)
        {
            animator.SetBool("Abrir_puerta",true);
            Destroy(GetComponent<BoxCollider2D>());
            efectoaudio.GetComponent<AudioSource>().PlayOneShot(efectoaudio.sonido1);
        }

    }

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
        }
    }

}
 