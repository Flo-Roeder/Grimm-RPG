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

    [SerializeField]public Vector2 moveInput;

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

    [SerializeField]private bool _canMove;
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = anim.GetBool(AnimStrings.canMove); }
    }

    public float moveSpeed ;

    public float dashSpeed;

    public Vector2 appliedDashForce;
    [SerializeField] float dashTime;
    public bool canDash=true;
    public float dashCooldown;
    private float dashTimer;
    [SerializeField] int dashStaminaCost;

    [SerializeField] GameObject playerBomb;

    public PlayerHealthController healthController;

    public CollectableInventory collectableInventory;
    public GearInventory gearInventory;
    public PlayerStats playerStats;
    public bool abilityStarted;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        SetStats();
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
                healthController.canDash = true;
                dashTimer = dashCooldown;
            }
        }
    }

    private void FixedUpdate()
    {
        if(anim.GetBool(AnimStrings.canMove))
        {
            rb.velocity = new Vector2(moveInput.x*(moveSpeed+appliedDashForce.x), moveInput.y*(moveSpeed+appliedDashForce.y));

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if (rb.velocity!=Vector2.zero)
        {
            anim.SetFloat(AnimStrings.xVelocity, rb.velocity.x/(moveSpeed+appliedDashForce.x));
            anim.SetFloat(AnimStrings.yVelocity, rb.velocity.y/(moveSpeed+appliedDashForce.y));
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();
        moveInput.y *= 0.5f; //isometric factor
        IsMoving = moveInput != Vector2.zero;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (dashStaminaCost<=healthController.playerStats.currentStamina
            && moveInput!=Vector2.zero)
        {
            if (context.started
                  && canDash
                  &&anim.GetBool(AnimStrings.canMove))
            {
                anim.SetTrigger(AnimStrings.isBlocking);
                appliedDashForce = new Vector2(Mathf.Abs(anim.GetFloat(AnimStrings.xVelocity)), Mathf.Abs(anim.GetFloat(AnimStrings.yVelocity)) ) * dashSpeed;
                StartCoroutine(DashCo());
                canDash = false;
                healthController.TakeStamina(dashStaminaCost,canDash);
            }
        }
    }

    public void DashWithoutInput()
    {
        if (dashStaminaCost <= healthController.playerStats.currentStamina
    && moveInput != Vector2.zero)
        {
            if (canDash
                  && anim.GetBool(AnimStrings.canMove))
            {
                anim.SetTrigger(AnimStrings.isBlocking);
                appliedDashForce = new Vector2(Mathf.Abs(anim.GetFloat(AnimStrings.xVelocity)), Mathf.Abs(anim.GetFloat(AnimStrings.yVelocity))) * dashSpeed;
                StartCoroutine(DashCo());
                canDash = false;
                healthController.TakeStamina(dashStaminaCost, canDash);
            }
        }

    }

    private IEnumerator DashCo()
    {
        yield return new WaitForSeconds(dashTime);
        appliedDashForce = Vector2.zero;
    }


    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started
            && playerStats.attackStaminaCost<=playerStats.currentStamina)
        {
            anim.SetTrigger(AnimStrings.isAttacking);
        }
    }

    public void SetStats()
    {
        moveSpeed = playerStats.moveSpeed;
        dashSpeed = playerStats.dashSpeed;
        dashTime = playerStats.dashTime;
        dashCooldown = playerStats.dashCooldown;
        dashStaminaCost = (int)playerStats.dashStaminaCost;
    }

    public void PlaceBomb(InputAction.CallbackContext context)
    {
        if (context.started
            && collectableInventory.bombs>0)
        {
            collectableInventory.bombs--;
            GameObject.FindGameObjectWithTag("CollectableUI").GetComponent<CollectablesUI>().CollectableUIUpdate();
            Vector3 _bombPosition = new Vector3(anim.GetFloat(AnimStrings.xVelocity), anim.GetFloat(AnimStrings.yVelocity)*2,0)*3
                                                + new Vector3 (transform.position.x, transform.position.y-1,transform.position.z);

            Instantiate(playerBomb,_bombPosition, Quaternion.identity);
        }
    }


}
