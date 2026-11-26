using UnityEngine;
using UnityEngine.InputSystem;

public class FuelPickup : MonoBehaviour
{   
   
    public float fuelAmount = 50f;

    public bool pickupAllowed;
    public Lyhty playerLyhty;
    
    public void PickUp(InputAction.CallbackContext context)
    {       Debug.Log("Fuel pickup attempted");
        Debug.Log(pickupAllowed);
        if (pickupAllowed && context.performed && playerLyhty != null)
        {
            
            playerLyhty.currentFuel = Mathf.Min(playerLyhty.currentFuel + fuelAmount, playerLyhty.fuelCapacity);
            Destroy(gameObject);
            Debug.Log("Fuel picked up");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            playerLyhty = other.GetComponent<Lyhty>();
            pickupAllowed = true;
            
            Debug.Log("Player entered trigger");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            playerLyhty = null;
            pickupAllowed = false;
            Debug.Log("Player exited trigger");
        }
    }
}
