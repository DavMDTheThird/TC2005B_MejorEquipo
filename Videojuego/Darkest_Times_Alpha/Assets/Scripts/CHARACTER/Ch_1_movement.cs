using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_1_movement : MonoBehaviour
{
    //Player
    Player_stats playerStats;
    Vector2 movement;

    public float runSpeed = 2f;
    public float runSprint = 2f;

    Vector2 mousePos;


    //Player Animation
    Rigidbody2D rb2d;
    public Animator animator;

    //Canvas
    Canvas heartsCanvas;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<Player_stats>();
    }


    void Update()
    {
        //Player Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Animation characteristics
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Look
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        //transform.localRotation = Quaternion.Euler(0, 0, angle);

        animator.SetFloat("Look_x", mousePos.x - transform.position.x);
        animator.SetFloat("Look_y", mousePos.y - transform.position.y);

        
    }


    private void FixedUpdate()
    {
        // Codigo par que no se mueva en diagonal mas rapido
        rb2d.velocity = new Vector2(movement.x, movement.y).normalized * runSpeed;

        // Codigo para el Sprint
        rb2d.MovePosition(rb2d.position + movement * runSpeed * Time.fixedDeltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.MovePosition(rb2d.position + movement * runSprint * Time.fixedDeltaTime);
        }
        
    }


    // Diferentes coliciones y eventos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.tag == "ObjetoRecogibleV")
        {
            Debug.Log("Poci?n de vida" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleE")
        {
            Debug.Log("Recogiste un escudo" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleS")
        {
            Debug.Log("Poci?n de Stamina" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleVel")
        {
            Debug.Log("Poci?n de Velocidad" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleA")
        {
            Debug.Log("Poci?n de Ataque" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }*/
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("Se agarro un item: " + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigos")
        {
            //Debug.Log("Te hizo daino: " + collision.gameObject.name);
            playerStats.TakeDamage(1);

            //Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }
    }

}