using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody2D rb;
    Rigidbody rb;
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
    public float dashSpeed;

    [SerializeField] Vector2 appliedDashForce;
    public bool canDash=true;
    public float dashCooldown;
    private float dashTimer;


    private void Awake()
    {
       // rb= GetComponent<Rigidbody2D>();
       rb= GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }

    void Start()
    {
        dashTimer = dashCooldown;
    }

    void Update()
    {
        if (!canDash)
        {
            if (dashTimer > 0)
            {
                dashTimer -= Time.deltaTime;
            }
            else if (dashTimer<=0)
            {
                canDash= true;
                dashTimer = dashCooldown;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x*moveSpeed+appliedDashForce.x, moveInput.y*moveSpeed+appliedDashForce.y);
        if (rb.velocity!=Vector3.zero)
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

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed
            && canDash)
        {
            appliedDashForce = new Vector2(anim.GetFloat(AnimStrings.xVelocity), anim.GetFloat(AnimStrings.yVelocity))*dashSpeed;
            canDash= false;
        }
        else if(context.canceled)
        {
            appliedDashForce = Vector2.zero;
        }


    }

}
