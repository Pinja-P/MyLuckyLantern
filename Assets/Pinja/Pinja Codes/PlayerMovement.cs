using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Player
    private Rigidbody2D playerRB;

    // Connections
    public Camera CameraScript;

    //Movement
    float moveSpeed;
    public float walkSpeed = 5f;
    private Vector2 moveInput;

    //Sneak
    public float sneakSpeed = 2f;

    //BatCarry
    public bool batCarry = false;
    public GameObject batCarrier;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;

        BatCarry(); // Checks if bat has caught player
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

            transform.position = batCarrier.transform.position;
            return;
        }
    }

   
}
