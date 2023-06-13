/*
Script to control the motion of an agent that uses
NavMesh in 2D

Gilberto Echeverria
2023-04-10
*/

using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class MovementIA : MonoBehaviour
{
    [SerializeField] Transform target;
    private bool isFound;

    NavMeshAgent nvAgent;

    [SerializeField] private float velocidad;
    [SerializeField] private Transform[] puntosMov;
    [SerializeField] private float distanciaMinima;
    private int numAleatorio;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        isFound = false;
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.updateRotation = false;
        nvAgent.updateUpAxis = false;
        numAleatorio = Random.Range(0,puntosMov.Length);
        sprite = GetComponent<SpriteRenderer>();
        Girar();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFound)
         {
                target = GameObject.FindWithTag("Player").transform;
                isFound = true;
        }else{
            nvAgent.destination = target.position;
            transform.position = Vector2.MoveTowards(transform.position,puntosMov[numAleatorio].position,velocidad*Time.deltaTime);
            if(Vector3.Distance(transform.position,puntosMov[numAleatorio].position)<distanciaMinima)
            {
                numAleatorio = Random.Range(0,puntosMov.Length);
                Girar();
            }
        }
        
    }

    private void Girar()
    {
        if(transform.position.x<puntosMov[numAleatorio].position.x){
            sprite.flipX = true;
        }else{
            sprite.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isFound = true;
            Debug.Log("Lo encontro");
        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isFound = true;
            Debug.Log("Lo encontro");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isFound = false;
            Debug.Log("No lo encontro");
        }
    }
    
}
