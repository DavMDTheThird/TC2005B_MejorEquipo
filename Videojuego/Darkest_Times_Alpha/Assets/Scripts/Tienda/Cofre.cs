using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    Animator myAnim;
    [SerializeField] private GameObject MarcaDialogo;
    public bool JugadorCerca;

    public GameObject cofreItem;
    public float cofreDelay;

    bool itemPicked = false;

    public int itemAmount;
    int itemCount;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            MarcaDialogo.SetActive(true);
            JugadorCerca = true;
        }
    }
    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            JugadorCerca = false;
            MarcaDialogo.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !itemPicked && JugadorCerca)
        {
            MarcaDialogo.SetActive(false);
            myAnim.Play("cofre_abrir");
            StartCoroutine(GetChestItem());
        }
    }

    IEnumerator GetChestItem()
    {
        while(itemCount<itemAmount)
        {
            yield return new WaitForSeconds(cofreDelay);
            Instantiate(cofreItem, transform.position, Quaternion.identity);
            itemPicked = true;

            itemCount++;
        }
    }
}
