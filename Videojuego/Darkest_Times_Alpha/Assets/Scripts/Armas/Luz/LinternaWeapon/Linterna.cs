using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public float coolDownL;
    private int atkLinterna = 15;// Atk de la linterna
    public bool IsBroken = false;// Booleano que verifica si esta apunto de romperse

    // Start is called before the first frame update
    void Start()
    {
        coolDownL = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.IsBroken == false){
            coolDownL -= Time.deltaTime;
        }
        if(coolDownL <= 0){
            this.IsBroken = true;
            Destroy(gameObject);
            Debug.Log("Se rompe");
        }
    }
}
