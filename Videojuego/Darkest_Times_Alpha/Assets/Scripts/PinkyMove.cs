using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyMove : MonoBehaviour
{
    float horizontal;

    float vertical;

    public float runSpeed = 2;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}