using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : MonoBehaviour
{
    [SerializeField] GameObject mechero;
    private GameObject jugador;
    inventarioPrueba inventario;
    public EfectosSonido efectoaudio;
    [SerializeField] private AudioClip colectar;
    private bool equipada;
    private float coolDownM; //EL cooldown max que tiene todas las armas
    public bool IsBroken = false;// Booleano que verifica si esta apunto de romperse
    public int slot;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        inventario = jugador.GetComponent<inventarioPrueba>();
        coolDownM = 100f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(equipada){
            if(this.IsBroken == false){
                coolDownM -= Time.deltaTime;
                //LuzBar.instance.UseLuz(0.0045f);
            }
            if(coolDownM <= 0){
                ControladorSonidos.Instance.EjecutarSonido(colectar);
                this.IsBroken = true;
                Destroy(inventario.isFull[slot]);
                Destroy(gameObject);
                Debug.Log("Se rompe");
            }
            Debug.Log("Te quedan " + coolDownM + " segundos.");
            
        }
    }

    public void Equipar()
    {
        efectoaudio.GetComponent<AudioSource>().PlayOneShot(efectoaudio.sonido1);
        equipada = !equipada;
        inventario.isFull[slot].SetActive(equipada);
    }
}
