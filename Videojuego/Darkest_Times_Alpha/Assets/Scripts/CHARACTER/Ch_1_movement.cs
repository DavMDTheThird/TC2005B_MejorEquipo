using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_1_movement : MonoBehaviour
{
    Vector2 movement;

    public float runSpeed = 2f;
    public float runSprint = 2f;

    Rigidbody2D rb2d;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * runSpeed * Time.fixedDeltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.MovePosition(rb2d.position + movement * runSprint * Time.fixedDeltaTime);
        }
        
    }

<<<<<<< HEAD
=======

    //Esta funcion no debe de estar aqui, y debe de mejorarse que se borran los tags, entonces por si hay mas objetos del mismo tag no funciona.
    //Tambien si se hace una colision con otro elemento con el mismo sitema de colider (como el el mueble) se borra la pocion.
>>>>>>> main
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ObjetoRecogibleV")
        {
            Debug.Log("Poci�n de vida" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleE")
        {
            Debug.Log("Recogiste un escudo" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleS")
        {
            Debug.Log("Poci�n de Stamina" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleVel")
        {
            Debug.Log("Poci�n de Velocidad" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleA")
        {
            Debug.Log("Poci�n de Ataque" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }
    }
}