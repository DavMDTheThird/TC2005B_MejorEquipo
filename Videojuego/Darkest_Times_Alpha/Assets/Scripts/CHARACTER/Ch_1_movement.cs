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

    //[SerializeField] private float fireRate = 0.5f;


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
        // Codigo par que no se mueva en diagonal mas rapido
        rb2d.velocity = new Vector2(movement.x, movement.y).normalized * runSpeed;

        // Codigo para el Sprint
        rb2d.MovePosition(rb2d.position + movement * runSpeed * Time.fixedDeltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.MovePosition(rb2d.position + movement * runSprint * Time.fixedDeltaTime);
        }
        
    }


    private void Shoot()
    {
        Instantiate(BulletPrefab, firingPoint.position, firingPoint.rotation);
    }

    // Diferentes coliciones y eventos
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        }
    }
}