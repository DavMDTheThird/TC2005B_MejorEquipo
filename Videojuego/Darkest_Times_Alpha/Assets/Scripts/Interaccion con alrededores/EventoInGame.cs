using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoInGame : MonoBehaviour
{
    [SerializeField] public GameObject gameObject;

    private void OnTriggerEnter2D()
    {
        gameObject.SetActive(true);
    }

    
}
