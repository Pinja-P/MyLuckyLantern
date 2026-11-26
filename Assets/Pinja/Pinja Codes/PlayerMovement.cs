using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Player
    private Rigidbody2D playerRB;

    // Connections
    public Kamera CameraScript;

    //Movement
    float moveSpeed;
    public float walkSpeed = 5f;
    private Vector2 moveInput;

    //Sneak
    public float sneakSpeed = 2f;

    //BatCarry
    public bool batCarry = false;
    public GameObject batCarrier;

    // Animation
    public Animator animator;
    float facingDirection = 1;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;

        BatCarry(); // Checks if bat has caught player

        Flip(); // Flips the player sprite

        HandleAnimations(); 
    }

    // Input System (Makes player able to move)
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Sneak if putton is held down
    public void Sneak(InputAction.CallbackContext context)
    {
        if (context.performed && !batCarry)
        {
            moveSpeed = sneakSpeed;
            Debug.Log("Sneaking");
        }

        if (context.canceled && !batCarry)
        {
            moveSpeed = walkSpeed;
            Debug.Log("Walking");
        }

    }

    public void BatCarry()
    {
        if (batCarry)
        {
            CameraScript.StopCamera();
        }
        if (batCarry)
        {
            if (batCarrier == null)
            {
                batCarry = false;
                return;
            }

            transform.position = batCarrier.transform.position;
            return;
        }
    }

    void HandleAnimations()
    {
        animator.SetBool("isIdle", Mathf.Abs(moveInput.x) < 0.1 && Mathf.Abs(moveInput.y) < 0.1);
        animator.SetBool("isWalking", Mathf.Abs(moveInput.x) > 0.1f || Mathf.Abs(moveInput.y) > 0.1f);
    }

    private void Flip()
    {
        if(moveInput.x > 0.1f )
        {
            facingDirection = 1;
        }
        else if (moveInput.x < -0.1f)
        {
            facingDirection = -1;
        }

        transform.localScale = new Vector3(facingDirection, 1, 1);
    }

    public void PausePlayer()
    {
        moveSpeed = 0;
    }

    public void RestartPlayer()
    {
        moveSpeed = walkSpeed;
    }
}