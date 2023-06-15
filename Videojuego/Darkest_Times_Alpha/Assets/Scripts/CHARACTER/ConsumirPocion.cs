using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumirPocion : MonoBehaviour
{
    [SerializeField] ObjetosPociones objetosPocions;
    public Vidas vida;

    private GameObject[] playerList;
    private GameObject player;
    private Player_stats playerStats;
    public int slot;
        
    public enum ObjetosPociones
    {
        Stamina,
        Vida,
        Ataque,
        Escudo
    };

    public void UsarObjetos()
    {
        switch(objetosPocions)
        {
            case ObjetosPociones.Stamina:
                Debug.Log("Consumir pocion stamina");
                //playerStats.
                break;
            case ObjetosPociones.Vida:
                Debug.Log("Consumir pocion vida");

                playerList = GameObject.FindGameObjectsWithTag("Player");
                player = playerList[0];
                playerStats = GetComponent<Player_stats>();

                Debug.Log(player.name);

                playerStats.TakeDamage(-1);
                break;
            case ObjetosPociones.Ataque:
                Debug.Log("Consumir pocion ataque");
                break;
            case ObjetosPociones.Escudo:
                Debug.Log("Consumir escudo");
                break;
        }

        Destroy(this.gameObject);

    }
}
