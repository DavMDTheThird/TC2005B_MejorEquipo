using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemigo : MonoBehaviour
{
    Player_stats playerStats;
    Canvas heartsCanvas;
    [SerializeField] private GameObject enemigo;
    public short vida;
    public short atk;
    private bool recibeDaño;
    private float timeToDamage;
    public float damageDelay;
    // Start is called before the first frame update
    void Start()
    {
        timeToDamage = 0;
        //playerStats = GetComponent<Player_stats>();
        if(enemigo.tag == "eyeBall"){
            vida = 20;
            atk = 2;
        }
        if(enemigo.tag == "spider"){
            vida = 3;
            atk = 3;
        }
        if(enemigo.tag == "clump"){
            atk = 1;
        }
    }

    void Update()
    {
        if(vida<=0)
        {
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("linterna"))
    //         {
    //             vida -= 15;
    //         }
    //         if (collision.CompareTag("mechero"))
    //         {
    //             vida -= 5;
    //         }
    //         if (collision.CompareTag("antorcha"))
    //         {
    //             vida -= 10;
    //         }
    // }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("linterna") && Time.time >= timeToDamage)
            {
                vida -= 15;
                timeToDamage = Time.time + damageDelay;
            }
            if (collision.CompareTag("mechero") && Time.time >= timeToDamage)
            {
                vida -= 5;
                timeToDamage = Time.time + damageDelay;
            }
            if (collision.CompareTag("antorcha") && Time.time >= timeToDamage)
            {
                vida -= 10;
                timeToDamage = Time.time + damageDelay;
            }
    }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     recibeDaño = false;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(atk);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && enemigo.tag == "clump")
        {
            playerStats.TakeDamage(atk);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(atk);
        }
    }

}
