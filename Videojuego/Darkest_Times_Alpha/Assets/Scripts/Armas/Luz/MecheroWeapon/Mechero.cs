using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : MonoBehaviour
{
    [SerializeField] GameObject mechero;
    private GameObject jugador;
    inventarioPrueba inventario;
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
            }
            if(coolDownM <= 0){
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
        equipada = !equipada;
        inventario.isFull[slot].SetActive(equipada);
    }
}
