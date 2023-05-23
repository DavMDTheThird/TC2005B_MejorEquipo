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


    //Esta funcion no debe de estar aqui, y debe de mejorarse que se borran los tags, entonces por si hay mas objetos del mismo tag no funciona.
    //Tambien si se hace una colision con otro elemento con el mismo sitema de colider (como el el mueble) se borra la pocion.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pocion de vida");
        Destroy(GameObject.FindGameObjectWithTag("VidaPocion"));
    }
}