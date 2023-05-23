using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform objectToFollow;
    public float yOffset = 1f;

    private GameObject[] objectToFollowTAG;

    void Start()
    {
        //Como se inicia el juego en diferentes puntos, buscar al jugador.
        objectToFollowTAG = GameObject.FindGameObjectsWithTag("Player");
        objectToFollow = objectToFollowTAG[0].transform;
        //Por si no encuentra ningun GameObject con el tag de: Player 
        if (objectToFollow == null)
        {
            Debug.LogWarning("Target object not found with tag: " + "Player");
        }
        //Centrar la camara en el personaje
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y + yOffset, -10f);
    }

    void Update()
    {
        //Debug.Log("Position X: " + transform.position.x + " Position Y: " + transform.position.y + " Position Z: " + transform.position.z);
        Vector3 newPos = new Vector3(objectToFollow.position.x, objectToFollow.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

}