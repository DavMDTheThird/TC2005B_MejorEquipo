using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    MovementIA movimiento;
    // Start is called before the first frame update
    void Start()
    {
        movimiento = transform.parent.GetComponent<MovementIA>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){
        movimiento.OnTriggerEnter2D(collision);
    }
    private void OnTriggerExit2D(Collider2D collision){
        movimiento.OnTriggerExit2D(collision);
    }
}
