using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCambio : MonoBehaviour
{
    public string CargarEscena;
    private Player_stats player;

    public void OnTriggerEnter2D(Collider2D otro)
    {
        Debug.Log(otro);
        player = otro.GetComponent<Player_stats>();
        Debug.Log(player);
        player.PutCheckpoint();

        if (otro.CompareTag("Player") && !otro.isTrigger)
        {
            SceneManager.LoadScene(CargarEscena);
        }
    }
}
