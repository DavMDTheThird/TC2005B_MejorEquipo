using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTienda : MonoBehaviour
{
    private inventarioPrueba invenPrueba;
    public GameObject itemButtom;

    private void Start()
    {
        invenPrueba = GameObject.FindGameObjectWithTag("Player").GetComponent<inventarioPrueba>();
    }
    // Start is called before the first frame update
    public void comprarObjeto()
    {
        for (int i = 0; i < invenPrueba.slots.Length; i++)
        {
            if (invenPrueba.isFull[i] == null)
            {
                invenPrueba.isFull[i] = Instantiate(itemButtom, invenPrueba.slots[i].transform, false);
                break;
            }
        }
    }
}
