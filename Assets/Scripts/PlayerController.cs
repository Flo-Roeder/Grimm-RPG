using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    private Vector2 moveInput;

    private bool _isMoving;
    public bool IsMoving {
        get
        {
            return _isMoving;
        }
        private set 
        {
            _isMoving = value;
            anim.SetBool(AnimStrings.isMoving, value);
        }
    }

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
        if (rb.velocity!=Vector2.zero)
        {
        anim.SetFloat(AnimStrings.xVelocity, rb.velocity.x/moveSpeed);
        anim.SetFloat(AnimStrings.yVelocity, rb.velocity.y/moveSpeed);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();
        IsMoving = moveInput != Vector2.zero;

    }

}
