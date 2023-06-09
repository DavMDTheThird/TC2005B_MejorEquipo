using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Transform player; // Reference to the GameObject to rotate around
    public float distance = 1f; // Fixed distance from the target

    //Gun and look
    Vector2 mousePos;



    public Animator animator;

    public float delay = 0.3f;

    private bool attackBlocked;





    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    public void Update()
    {
        //-------------- Posicion del arma respecto al mouse 
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPosition = player.transform.position;
        Vector3 desiredPosition = playerPosition + (mousePos - Camera.main.WorldToScreenPoint(playerPosition)).normalized * distance;

        transform.position = desiredPosition;



        //-------------- Rotacion del arma respecto al mouse ---------------
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - player.transform.position;

        // Para que no rote (el arma) si es que el mouse lo pone sobre el personaje
        if (direction.magnitude > distance)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }



        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

}
