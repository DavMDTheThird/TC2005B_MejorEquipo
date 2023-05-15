using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efecto_Sonido_Puerta : MonoBehaviour
{
    private AudioSource audio; //Clase privada de AudioSource llamada audio
    [SerializeField] private AudioClip efecto1; //Recolecta el audio clip

    private void Start(){ //Funcion que se inicializa al iniciar el juego
        audio = GetComponent<AudioSource>(); //Nuestra clase audio guarda y regresa el componente que se especifico
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Puerta"){ //Verifica si el tag del objeto es el de la puerta
            audio.Play();
        }
    }
}
