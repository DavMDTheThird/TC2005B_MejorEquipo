using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField] GameObject linterna;
    private GameObject jugador;
    inventarioPrueba inventario;
    private bool equipada;
    public float coolDownL;
    private int atkLinterna = 15;// Atk de la linterna
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
            }
            if(coolDownL <= 0){
                this.IsBroken = true;
                Destroy(gameObject);
                Debug.Log("Se rompe");
            }
            Debug.Log("Te quedan " + coolDownL + " segundos.");
        }
    }

    public void Equipar()
    {
        equipada = !equipada;
        inventario.isFull[slot].SetActive(equipada);
    }
}
