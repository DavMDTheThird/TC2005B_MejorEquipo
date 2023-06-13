using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private inventarioPrueba invenPrueba;
    public int i;

    private void Start()
    {
        invenPrueba = GameObject.FindGameObjectWithTag("Player").GetComponent<inventarioPrueba>();
    }

    private void Update()
    {
        if(transform.childCount<=0)
        {
            invenPrueba.isFull[i] = null;
        }
    }
    public void dropItem()
    {
        foreach(Transform child in transform)
        {
            /*child.GetComponent<Spawn>();*/
            GameObject.Destroy(child.gameObject);
        }
    }
}
