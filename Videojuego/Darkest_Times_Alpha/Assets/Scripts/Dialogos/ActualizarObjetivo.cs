using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActualizarObjetivo : MonoBehaviour
{
   [SerializeField] public TMP_Text texto;
   public string objetivo;

   private void OnTriggerEnter2D(){
    texto.text = objetivo;
   }
}
