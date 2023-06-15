using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField] GameObject linterna;
    private GameObject jugador;
    inventarioPrueba inventario;
    public EfectosSonido efectoaudio;
    [SerializeField] private AudioClip colectar;
    private bool equipada;
    private float coolDownL;
    public bool IsBroken = false;// Booleano que verifica si esta apunto de romperse
    public int slot;


    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        inventario = jugador.GetComponent<inventarioPrueba>();
        coolDownL = 20f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(equipada){
            if(this.IsBroken == false){
                coolDownL -= Time.deltaTime;
                //LuzBar.instance.UseLuz(0.016f);
                
            }
            if(coolDownL <= 0){
                ControladorSonidos.Instance.EjecutarSonido(colectar);
                this.IsBroken = true;
                Destroy(inventario.isFull[slot]);
                Destroy(gameObject);
                Debug.Log("Se rompe");
            }
            
            Debug.Log("Te quedan " + coolDownL + " segundos.");
        }
    }

    public void Equipar()
    {
        efectoaudio.GetComponent<AudioSource>().PlayOneShot(efectoaudio.sonido1);
        equipada = !equipada;
        inventario.isFull[slot].SetActive(equipada);
    }
}
