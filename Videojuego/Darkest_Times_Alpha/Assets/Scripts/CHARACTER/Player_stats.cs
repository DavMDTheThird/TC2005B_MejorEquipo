using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    Player_basic player = new Player_basic(10, 10, 0, 0, 50, 2, 4.5f, 5, 5, 0);
    

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            player.Info();
        }
    }

    public void TakeDamage(short damage)
    {
        player.HP -= damage;
        Debug.Log(transform.name + " took: " + damage + " damage. HP now: " + player.HP);
    }

    
}
