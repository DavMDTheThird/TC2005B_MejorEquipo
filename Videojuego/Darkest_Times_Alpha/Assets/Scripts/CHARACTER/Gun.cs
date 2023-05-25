using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector2 mousePos;
    public Transform target; // Reference to the GameObject to rotate around
    public float rotationSpeed = 1f;
    public float distance = 5f; // Fixed distance from the target


    void Start()
    {
        
    }

    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z));
        // Calculate the direction from the target to the mouse position
        Vector3 direction = worldMousePosition - target.position;
        // Normalize the direction vector and multiply it by the desired distance
        Vector3 desiredPosition = target.position + direction.normalized * distance;
        // Set the position of the GameObject to the desired position
        transform.position = desiredPosition;


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        //float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        //transform.localRotation = Quaternion.Euler(0, 0, angle);   
    }
}
