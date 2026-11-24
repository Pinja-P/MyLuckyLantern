using UnityEngine;
using UnityEngine.InputSystem;

public class FuelPickup : MonoBehaviour
{
    public float fuelAmount = 50f;

    private bool pickupAllowed;
    private Lyhty playerLyhty;

    public void PickUp(InputAction.CallbackContext context)
    {
        if (pickupAllowed && context.performed && playerLyhty != null)
        {
            playerLyhty.currentFuel = Mathf.Min(playerLyhty.currentFuel + fuelAmount, playerLyhty.fuelCapacity);
            Destroy(gameObject);
            Debug.Log("Fuel picked up");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerLyhty = other.GetComponent<Lyhty>();
            pickupAllowed = true;
            Debug.Log("Player entered trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerLyhty = null;
            pickupAllowed = false;
            Debug.Log("Player exited trigger");
        }
    }
}
