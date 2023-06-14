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
    private bool isInRange;

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
        isInRange = false;
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.updateRotation = false;
        nvAgent.updateUpAxis = false;
        numAleatorio = Random.Range(0,puntosMov.Length);
        target = puntosMov[numAleatorio];
        sprite = GetComponent<SpriteRenderer>();
        Girar();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFound)
         {
            nvAgent.destination = target.position;
        }else{
            nvAgent.destination = target.position;
            if(Vector2.Distance(nvAgent.transform.position,target.position)<distanciaMinima)
            {
                numAleatorio = Random.Range(0,puntosMov.Length);
                target = puntosMov[numAleatorio];
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
            target = collision.transform;
            isFound = true;
            Debug.Log("Lo encontro");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isFound = false;
            target = puntosMov[numAleatorio];
            Debug.Log("No lo encontro");
        }
    }
    
}
