using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechero : MonoBehaviour
{
    public float coolDownM; //EL cooldown max que tiene todas las armas
    private int atkMechero = 5; //Atk del mechero
    public bool IsBroken = false;// Booleano que verifica si esta apunto de romperse

    // Start is called before the first frame update
    void Start()
    {
        coolDownM = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.IsBroken == false){
            coolDownM -= Time.deltaTime;
        }
        if(coolDownM <= 0){
            this.IsBroken = true;
            Destroy(gameObject);
            Debug.Log("Se rompe");
        }
    }
}
