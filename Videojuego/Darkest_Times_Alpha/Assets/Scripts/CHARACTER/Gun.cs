using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform target; // Reference to the GameObject to rotate around
    public float rotationSpeed = 1f;
    public float distance = 5f; // Fixed distance from the target

    // Estas variables me ayudaran a mantener el curson pegado al personaje
    float maxX = 800f;
    float minX = 500f;
    float maxY = 400f;
    float minY = 100f;


    void Start()
    {
        
    }

    void Update()
    {
        //-------------- Posicion del arma respecto al mouse ---------------
        Vector3 mousePos = Input.mousePosition;
        Vector3 center = new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f, 0f);
        Vector3 clampedMousePos = center + Vector3.ClampMagnitude(mousePos - center, Mathf.Min((maxX - minX) / 2f, (maxY - minY) / 2f));

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(clampedMousePos.x, clampedMousePos.y, transform.position.z));
        transform.position = target.position + (worldMousePosition - target.position).normalized * distance;



        //-------------- Rotacion del arma respecto al mouse ---------------
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);  
    }
}
//------Cosas a hablar------
/*Para que el arma no se vaya mas alla del personaje, se tiene que poner el follow speed de la camara instantaneo, practicamente.*/



//----------Version pasada de posicion del arma------
//Vector3 mousePos = Input.mousePosition;

//mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
//mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);

//Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z));
// Calculate the direction from the target to the mouse position
//Vector3 direction = worldMousePosition - target.position;
// Normalize the direction vector and multiply it by the desired distance
//Vector3 desiredPosition = target.position + direction.normalized * distance;
// Set the position of the GameObject to the desired position
//transform.position = desiredPosition;
