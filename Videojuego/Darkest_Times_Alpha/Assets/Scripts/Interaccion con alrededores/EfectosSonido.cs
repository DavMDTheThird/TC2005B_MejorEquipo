using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosSonido : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] public AudioClip sonido1;

    private void Start(){
        audio = GetComponent<AudioSource>();

    }
}
