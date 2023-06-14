using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_tutorial: MonoBehaviour
{
    public string CargarEscena;

    public void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player") && !otro.isTrigger)
        {
            SceneManager.LoadScene(CargarEscena);
        }
    }
}
