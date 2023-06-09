using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemigo : MonoBehaviour
{
    Player_stats playerStats;
    Canvas heartsCanvas;
    [SerializeField] private GameObject enemigo;
    [SerializeField] private AudioClip colectar;
    [SerializeField] public GameObject creditos;
    private GameObject arma1;
    private GameObject arma2;
    private short vida;
    private short atk;
    private bool recibeDaño;
    private float timeToDamage;
    private float timeToAttack;
    public float damageDelay;
    public float attackDelay;
    // Start is called before the first frame update
    void Start()
    {
        timeToDamage = 0;
        playerStats = GetComponent<Player_stats>();
        if(enemigo.tag == "eyeBall"){
            vida = 50;
            atk = 2;
        }
        if(enemigo.tag == "spider"){
            vida = 100;
            atk = 3;
        }
        if(enemigo.tag == "clump"){
            atk = 1;
            vida = 1;
        }
        if(enemigo.tag == "legs"){
            atk = 150;
            vida = 4;
        }
    }

    void Update()
    {
        if(gameObject != null)
        {
            if (vida <= 0)
            {
                ControladorSonidos.Instance.EjecutarSonido(colectar);
                Destroy(gameObject);
            }
        }
        
        if(vida == 0 && enemigo.tag == "spider")
        {
            creditos.SetActive(true);
            ControladorSonidos.Instance.EjecutarSonido(colectar);
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
                    vida -= 20;
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
                if (collision.gameObject.tag == "espada" && Time.time >= timeToDamage )
                {
                    vida -= 20;
                    timeToDamage = Time.time + damageDelay;
                }
                if (collision.gameObject.tag == "bate" && Time.time >= timeToDamage )
                {
                    vida -= 10;
                    timeToDamage = Time.time + damageDelay;
                }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag == "Player" && enemigo.tag == "clump")
    //     {
    //         vida -= 1;
    //         playerStats = collision.gameObject.GetComponent<Player_stats>();
    //         playerStats.TakeDamage(atk);
    //     }
    //     if(collision.gameObject.tag == "Player")
    //     {
    //         playerStats = collision.gameObject.GetComponent<Player_stats>();
    //         playerStats.TakeDamage(atk);
    //     }
        
    // }

    private void OnCollisionStay2D(Collision2D collision)
    {
        arma1 = GameObject.FindGameObjectWithTag("bate");
        arma2 = GameObject.FindGameObjectWithTag("espada");
        if(collision.gameObject.tag == "Player" && enemigo.tag == "clump")
        {
            vida -= 1;
            playerStats = collision.gameObject.GetComponent<Player_stats>();
            playerStats.TakeDamage(atk);
        }
        if(collision.gameObject.tag == "Player" && Time.time >= timeToAttack)
        {
            playerStats = collision.gameObject.GetComponent<Player_stats>();
            playerStats.TakeDamage(atk);
            timeToAttack = Time.time + attackDelay;
        }
        if (collision.gameObject.tag == "bala" && Time.time >= timeToDamage )
        {
            vida -= 20;
            timeToDamage = Time.time + damageDelay;
        }
        if (collision.gameObject.tag == "proyectil" && Time.time >= timeToDamage )
        {
            vida -= 25;
            timeToDamage = Time.time + damageDelay;
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "bala" && Time.time >= timeToDamage && enemigo.tag != "eyeBall")
    //     {
    //         vida -= 20;
    //         timeToDamage = Time.time + damageDelay;
    //     }
    //     if (collision.gameObject.tag == "proyectil" && Time.time >= timeToDamage && enemigo.tag != "eyeBall")
    //     {
    //         vida -= 25;
    //         timeToDamage = Time.time + damageDelay;
    //     }
    //     if (collision.gameObject.tag == "espada" && Time.time >= timeToDamage && enemigo.tag != "eyeBall")
    //     {
    //         vida -= 15;
    //         timeToDamage = Time.time + damageDelay;
    //     }
    //     if (collision.gameObject.tag == "bate" && Time.time >= timeToDamage && enemigo.tag != "eyeBall")
    //     {
    //         vida -= 10;
    //         timeToDamage = Time.time + damageDelay;
    //     }

    // }

}
