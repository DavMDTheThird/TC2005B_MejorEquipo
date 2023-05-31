using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorcha : MonoBehaviour
{
    public float coolDownA;
    private int atkAntorcha = 10;// Atk de la antorcha
    public bool IsBroken = false;// Booleano que verifica si esta apunto de romperse

    // Start is called before the first frame update
    void Start()
    {
        coolDownA = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.IsBroken == false){
            coolDownA -= Time.deltaTime;
        }
        if(coolDownA <= 0){
            this.IsBroken = true;
            Destroy(gameObject);
            Debug.Log("Se rompe");
        }
    }
}
