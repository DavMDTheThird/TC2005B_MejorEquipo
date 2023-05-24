using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_1_movement : MonoBehaviour
{
    //Player
    Vector2 movement;

    public float runSpeed = 2f;
    public float runSprint = 2f;

    //Gun and look
    Vector2 mousePos;

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform firingPoint;

    [SerializeField] private float fireRate = 0.5f;


    //Player Animation
    Rigidbody2D rb2d;
    public Animator animator;

    




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        //Gun
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
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

    private void Shoot()
    {
        Instantiate(BulletPrefab, firingPoint.position, firingPoint.rotation);
    }


    //Esta funcion no debe de estar aqui, y debe de mejorarse que se borran los tags, entonces por si hay mas objetos del mismo tag no funciona.
    //Tambien si se hace una colision con otro elemento con el mismo sitema de colider (como el el mueble) se borra la pocion.
>>>>>>> main
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ObjetoRecogibleV")
        {
            Debug.Log("Poción de vida" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleE")
        {
            Debug.Log("Recogiste un escudo" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleS")
        {
            Debug.Log("Poción de Stamina" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleVel")
        {
            Debug.Log("Poción de Velocidad" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }

        if (collision.gameObject.tag == "ObjetoRecogibleA")
        {
            Debug.Log("Poción de Ataque" + collision.gameObject.name);
            Destroy(collision.gameObject); // se tiene que poner el collider y no el tag
        }
    }
}