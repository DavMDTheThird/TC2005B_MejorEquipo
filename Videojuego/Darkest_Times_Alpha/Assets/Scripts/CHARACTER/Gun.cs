using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform player; // Reference to the GameObject to rotate around
    public float distance = 1f; // Fixed distance from the target

    //Gun and look
    Vector2 mousePos;

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;
    private float fireTimer;


    void Update()
    {
        //Gun
        // Dispara cada cierto tiempo
        if (Input.GetMouseButtonDown(0) && fireTimer < 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
        {   //Para reducir el tiempo antes del siguiente disparo (mabe agregar un coroutine para el sonido)
            fireTimer -= Time.deltaTime;
        }


        //-------------- Posicion del arma respecto al mouse 
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPosition = player.transform.position;
        Vector3 desiredPosition = playerPosition + (mousePos - Camera.main.WorldToScreenPoint(playerPosition)).normalized * distance;

        transform.position = desiredPosition;



        //-------------- Rotacion del arma respecto al mouse ---------------
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - player.transform.position;

        // Para que no rote (el arma) si es que el mouse lo pone sobre el personaje
        if (direction.magnitude > distance)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, firingPoint.position, firingPoint.rotation);
    }

}
//------Cosas a hablar------
/*Para que el arma no se vaya mas alla del personaje, se tiene que poner el follow speed de la camara instantaneo, practicamente.*/
