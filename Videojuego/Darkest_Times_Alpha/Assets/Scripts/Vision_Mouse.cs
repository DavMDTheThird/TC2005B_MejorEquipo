using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision_Mouse : MonoBehaviour
{
    private Animator animator;
    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Guarda las el vector que se genera desde la camara hasta la posicion del cursor
        float angle = (Mathf.Atan2(targetDir.y , targetDir.x)*Mathf.Rad2Deg); //Obtiene el angulo tangente que se forma por el vector targetDir en grados
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
}
