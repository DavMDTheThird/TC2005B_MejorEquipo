// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TeclasInv : MonoBehaviour
// {
//     private inventarioPrueba inventario;
//     private GameObject jugador;
//     // Start is called before the first frame update
//     void Start()
//     {
//         jugador = GameObject.FindGameObjectWithTag("Player");
//         inventario = jugador.GetComponent<inventarioPrueba>();
//     }

//     private void activar()
//     {
//         if(inventario.isFull[0]!=null && Input.GetKeyDown(KeyCode.F1))
//         {
//             inventario.isFull[0].Equipar();
//         }
//         if(inventario.isFull[1]!=null && Input.GetKeyDown(KeyCode.F2))
//         {
//             inventario.isFull[1].Equipar();
//         }
//         if(inventario.isFull[2]!=null && Input.GetKeyDown(KeyCode.F3))
//         {
//             inventario.isFull[2].Equipar();
//         }
//         if(inventario.isFull[3]!=null && Input.GetKeyDown(KeyCode.F4))
//         {
//             inventario.isFull[3].Equipar();
//         }
//         if(inventario.isFull[4]!=null && Input.GetKeyDown(KeyCode.F5))
//         {
//             inventario.isFull[4].Equipar();
//         }
//     }
// }
