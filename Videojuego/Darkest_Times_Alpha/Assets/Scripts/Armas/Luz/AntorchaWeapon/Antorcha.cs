using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorcha : MonoBehaviour
{
   [SerializeField] GameObject antorcha;
    private GameObject jugador;
    inventarioPrueba inventario;
    private bool equipada;
    private float coolDownA; //EL cooldown max que tiene todas las armas
    public bool IsBroken = false;// Booleano que verifica si esta apunto de romperse
    public int slot;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        inventario = jugador.GetComponent<inventarioPrueba>();
        coolDownA = 70f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(equipada){
            if(this.IsBroken == false){
                coolDownA -= Time.deltaTime;
            }
            if(coolDownA <= 0){
                this.IsBroken = true;
                Destroy(inventario.isFull[slot]);
                Destroy(gameObject);
                Debug.Log("Se rompe");
            }
            Debug.Log("Te quedan " + coolDownA + " segundos.");
        }
    }

    public void Equipar()
    {
        equipada = !equipada;
        inventario.isFull[slot].SetActive(equipada);
    }
}
