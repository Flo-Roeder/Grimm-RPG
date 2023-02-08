using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public bool canInteract;
    public bool isInteracting;
    [SerializeField] GameObject interactCanvas;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        interactCanvas.SetActive(false);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetFloat(AnimStrings.xVelocity) < 0
    && interactCanvas.transform.localScale.x > 0
    ||
    anim.GetFloat(AnimStrings.xVelocity) > 0
    && interactCanvas.transform.localScale.x < 0
    )
        {
            interactCanvas.transform.localScale = new Vector3(-interactCanvas.transform.localScale.x, interactCanvas.transform.localScale.y, interactCanvas.transform.localScale.z);
        }

    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (canInteract && context.started)
        {
            isInteracting= true;
        }
    }

    public void CanInteract(bool _canInteract)
    {
        if (_canInteract==true)
        {
            interactCanvas.SetActive(true);
            canInteract = true;
        }
        else
        {
            interactCanvas.SetActive(false);
            canInteract = false;
        }
    }
}
