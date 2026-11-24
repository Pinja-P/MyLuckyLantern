using UnityEngine;
using UnityEngine.InputSystem;

public class Lyhty : MonoBehaviour
{
    [Header("Light Settings")]
    [Range(1, 3)]
    public int brightnessLevel = 2;

    [Header("1: Heikko")]
    public Sprite dimSprite;
    public float dimBurnMultiplier = 0.5f;

    [Header("2: Keskitaso")]
    public Sprite midSprite;
    public float midBurnMultiplier = 1.0f;

    [Header("3: Kirkas")]
    public Sprite brightSprite;
    public float brightBurnMultiplier = 2.0f;

    [Header("Fuel Settings")]
    public float fuelCapacity = 100f;
    public float fuelBurnout = 1f;
    public float currentFuel;
    internal static Lyhty instance;

    private void Awake()
    {
        instance = this;
        currentFuel = fuelCapacity;
    }

    public void Start()
    {
        
    }

    private void Update()
    {
        HandleFuel();
    }

    public void HandleFuel()
    {
        if (currentFuel <= 0f) return;

        float multiplier = midBurnMultiplier;
        if (brightnessLevel == 1) multiplier = dimBurnMultiplier;
        else if (brightnessLevel == 3) multiplier = brightBurnMultiplier;

        currentFuel -= fuelBurnout * Time.deltaTime * multiplier;

        if (currentFuel <= 0f)
        {
            currentFuel = 0f;
        }
    }

    public void LightDown(InputAction.CallbackContext context)
    {
        if (currentFuel <= 0f) return;

        if (context.performed)
        {
            brightnessLevel = Mathf.Clamp(brightnessLevel - 1, 1, 3);
            Debug.Log("Brightness decreased to: " + brightnessLevel);
        }
    }

    public void LightUp(InputAction.CallbackContext context)
    {
        if (currentFuel <= 0f) return;

        if (context.performed)
        {
            brightnessLevel = Mathf.Clamp(brightnessLevel + 1, 1, 3);
            Debug.Log("Brightness increased to: " + brightnessLevel);
        }
    }
}
