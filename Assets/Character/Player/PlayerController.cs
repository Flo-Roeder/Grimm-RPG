using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public Animator anim;

    public Vector2 moveInput;

    private bool _isMoving;
    public bool IsMoving
    {
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

    [SerializeField] private bool _canMove;
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = anim.GetBool(AnimStrings.canMove); }
    }

    public float moveSpeed;


    public Vector2 appliedDashForce; //gets set by dash ability

    [SerializeField] GameObject playerBomb;

    public PlayerHealthController healthController;

    public CollectableInventory collectableInventory;
    public GearInventory gearInventory;
    public AbilityInventory abilityInventory;
    public PlayerStats playerStats;
    public bool abilityStarted;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetStats();
    }

    void Start()
    {
    }

    void Update()
    {

        TurnPlayer();

    }

    private void TurnPlayer()
    {
        //only if the current transform doesnt match the stored xVelocity
        if (anim.GetFloat(AnimStrings.xVelocity) < 0
           && transform.localScale.x > 0
           ||
           anim.GetFloat(AnimStrings.xVelocity) > 0
           && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }

    private void FixedUpdate()
    {


        //dash out of standing position
        if (moveInput == Vector2.zero
            && appliedDashForce != Vector2.zero)
        {
            rb.velocity = new Vector2(anim.GetFloat(AnimStrings.xVelocity) * (moveSpeed + appliedDashForce.x), anim.GetFloat(AnimStrings.yVelocity) * (moveSpeed + appliedDashForce.y));
            return;
        }

        //dashing while moving
        if (appliedDashForce != Vector2.zero)
        {
            rb.velocity = new Vector2(moveInput.x * (moveSpeed + appliedDashForce.x), moveInput.y * (moveSpeed + appliedDashForce.y));
            return;
        }

        //move restriction
        if (!anim.GetBool(AnimStrings.canMove))
        {
            rb.velocity = Vector2.zero;
            return;
        }

        //applie move velocity
        if (moveInput != Vector2.zero)
        {
            rb.velocity = new Vector2(moveInput.x * (moveSpeed + appliedDashForce.x), moveInput.y * (moveSpeed + appliedDashForce.y));
            IsMoving = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        //setting the animation variables
        if (rb.velocity != Vector2.zero)
        {
            anim.SetFloat(AnimStrings.xVelocity, rb.velocity.x / (moveSpeed + appliedDashForce.x));
            anim.SetFloat(AnimStrings.yVelocity, rb.velocity.y / (moveSpeed + appliedDashForce.y));
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();
        moveInput.y *= 0.5f; //isometric factor
        IsMoving = moveInput != Vector2.zero;

    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started
            && playerStats.attackStaminaCost <= playerStats.currentStamina)
        {
            anim.SetTrigger(AnimStrings.isAttacking);
        }
    }

    public void SetStats()
    {
        moveSpeed = playerStats.moveSpeed;
    }

    //TO DO exklude or rework
    public void PlaceBomb(InputAction.CallbackContext context)
    {
        if (context.started
            && collectableInventory.bombs > 0)
        {
            collectableInventory.bombs--;
            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
            Vector3 _bombPosition = new Vector3(anim.GetFloat(AnimStrings.xVelocity), anim.GetFloat(AnimStrings.yVelocity) * 2, 0) * 3
                                                + new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

            Instantiate(playerBomb, _bombPosition, Quaternion.identity);
        }

    }
}
