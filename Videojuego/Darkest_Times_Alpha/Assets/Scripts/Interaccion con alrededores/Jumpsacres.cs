using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumpsacres : MonoBehaviour
{
    [Header("Sonido")]
    private AudioSource audio;
    [SerializeField] private AudioClip clip;
    [Header("Imagen")]
    [SerializeField] private GameObject screamer;
    public int tiemposcream;

    private void Start(){
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        {
            screamer.SetActive(true);
            audio.PlayOneShot(clip);
            Destroy(this.gameObject,tiemposcream);
            Destroy(screamer,tiemposcream);
        }
    }
}
