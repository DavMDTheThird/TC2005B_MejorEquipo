using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool Activar_inv;
    public GameObject Selector;
    public int ID;


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Item"))
        {
            for (int i=0; i < Bag.Count; i++)
            {
                if (Bag[i].GetComponent<Image>().enabled == false)
                {
                    Bag[i].GetComponent<Image>().enabled = true;
                    Bag[i].GetComponent<Image>().sprite = coll.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
        }
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.L) && ID < Bag.Count - 1)
        {
            ID++;
        }
        if (Input.GetKeyDown(KeyCode.J) && ID > 0)
        {
            ID--;
        }
        if (Input.GetKeyDown(KeyCode.I) && ID > 2)
        {
            ID -= 3;
        }
        if (Input.GetKeyDown(KeyCode.K) && ID < 3)
        {
            ID += 3;
        }
        Selector.transform.position = Bag[ID].transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Navegar();

        if (Activar_inv)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Activar_inv = !Activar_inv;
        }
    }
}
