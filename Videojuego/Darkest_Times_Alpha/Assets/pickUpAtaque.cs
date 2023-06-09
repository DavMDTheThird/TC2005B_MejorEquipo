using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpAtaque : MonoBehaviour
{
    private inventarioPrueba invenPrueba;
    public GameObject itemButtom;

    private void Start()
    {
        invenPrueba = GameObject.FindGameObjectWithTag("Player").GetComponent<inventarioPrueba>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleE")
        {
            for(int i=0; i<invenPrueba.slots.Length; i++)
            {
                if(invenPrueba.isFull[i] == false)
                {
                    invenPrueba.isFull[i] = true;
                    Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleA")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == false)
                {
                    invenPrueba.isFull[i] = true;
                    Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        if (collision.CompareTag("Player") && gameObject.tag == "ObjetoRecogibleS")
        {
            for (int i = 0; i < invenPrueba.slots.Length; i++)
            {
                if (invenPrueba.isFull[i] == false)
                {
                    invenPrueba.isFull[i] = true;
                    Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
