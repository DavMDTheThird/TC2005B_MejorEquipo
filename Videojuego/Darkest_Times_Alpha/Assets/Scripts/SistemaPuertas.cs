using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuertas : MonoBehaviour
{

    public GameObject interactuar; //Objeto 
    public GameObject realizarAccion;//Objeto
    public bool mostarInteractuar;
    public bool mostrarRealizarAccion;
    public LayerMask personaje;//COntrolamos las capas del objeto personaje;

    [SerializeField] private Sprite puertaAbierta; //Cambio vacion que tendra la imagen de la puerta abierta
    // Start is called before the first frame update
    void Start()
    {
        interactuar.gameObject.SetActive(false);//Inicializa el objeto en un estado de pausa o desactivado
        realizarAccion.gameObject.SetActive(false);//Inicializa el objeto en un estado de pausa o desactivado
    }

    // Update is called once per frame
    void Update()
    {
        mostarInteractuar = Physics2D.OverlapCircle(this.transform.position,1f,personaje);//Detecta si hay una colision en un circulo plano en 2d
        mostrarRealizarAccion = Physics2D.OverlapCircle(this.transform.position,1f,personaje);//Detecta si hay una colision en un circulo plano en 2d
        if(mostarInteractuar==true){
            interactuar.gameObject.SetActive(true);//Activa el objeto
        }
        if(mostrarRealizarAccion == true && Input.GetKeyDown(KeyCode.E)){
            realizarAccion.gameObject.SetActive(true);
        }
    }

}
