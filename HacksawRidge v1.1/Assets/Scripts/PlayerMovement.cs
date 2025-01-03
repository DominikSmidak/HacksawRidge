using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float speedX, speedY;
    private Rigidbody2D rb;
    private Vector2 input;
    public Animator anim;
    private bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        Animate();
    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }

    private void GetInput()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        input = new Vector2(speedX, speedY);
        input.Normalize();
    }

    private void Animate()
    {
        if(input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        } else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("X", speedX);
            anim.SetFloat("Y", speedY);
        }

        anim.SetBool("Moving", moving);
    }
}
