using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonidos : MonoBehaviour
{
    public static ControladorSonidos Instance;
    private AudioSource audio;

    private void Awake(){
        
        if(Instance==null){
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }else{
            Destroy(gameObject);
        }
        audio = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido){
        audio.PlayOneShot(sonido);
    }
}
