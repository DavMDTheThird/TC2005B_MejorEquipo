using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemigo : MonoBehaviour
{
    Player_stats playerStats;
    Canvas heartsCanvas;
    [SerializeField] private GameObject enemigo;
    private float vida;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<Player_stats>();
        if(enemigo.tag == "eyeBall"){
            vida = 20;
        }
    }

    void Update()
    {
        if(vida<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "linterna")
        {
            vida -= 15;
        }
        if (collision.gameObject.tag == "mechero")
        {
            vida -= 5;
        }
    }
    
}
