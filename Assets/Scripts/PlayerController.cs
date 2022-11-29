using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    private Vector2 moveInput;
    public float moveSpeed;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x*moveSpeed, moveInput.y*moveSpeed);
        anim.SetFloat(AnimStrings.xVelocity, rb.velocity.x);
        anim.SetFloat(AnimStrings.yVelocity, rb.velocity.y);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();


    }

}
