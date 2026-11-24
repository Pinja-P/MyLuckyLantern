using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;

    // Camera
    [SerializeField] private CinemachineCamera camA;
    [SerializeField] private CinemachineCamera camB;
    bool CameraA = true;
    bool CameraB = false;

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
        
        BatCarry();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Sneak(InputAction.CallbackContext context)
    {
        if (context.performed && CameraA)
         {
             moveSpeed = sneakSpeed;
             Debug.Log("Sneaking");
         }

        if (context.canceled)
        {
            moveSpeed = walkSpeed;
            Debug.Log("Walking");
        }

    }

    public void BatCarry()
    {
        if (batCarry && CameraA)
        {
            SwitchToCamB();
            Debug.Log("Camera B");
        }
        if (batCarry)
        {
            
            transform.position = batCarrier.transform.position;
            return;
        }
        
    }

    public void SwitchToCamA()
    {
        camA.Priority = 10;
        camB.Priority = 5;
        CameraA = true;
        CameraB = false;

        Debug.Log("Camera A");
    }

    public void SwitchToCamB()
    {
        camB.transform.position = playerRB.position;
        camB.LookAt = null;
        camB.Follow = null;
        camB.Priority = 10;
        camA.Priority = 5;

        CameraA = false;
        CameraB = true;

        Debug.Log("Camera B");
    }
}
