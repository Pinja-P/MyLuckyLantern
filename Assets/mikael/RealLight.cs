using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RealLight : MonoBehaviour
{
    public Lyhty lyhty;

    [Header("Lights")]
    public Light2D realLight;        
    public Light2D secondaryLight;  

    [Header("Secondary Light Settings")]
    public float dimIntensity = 0.5f;
    public float dimRadius = 3f;

    public float midIntensity = 1.0f;
    public float midRadius = 5f;

    public float brightIntensity = 1.5f;
    public float brightRadius = 8f;
    public GameObject Animator;
    private int lastBrightnessLevel = -1;

    void Start()
    {
        if (realLight == null)
        {
            realLight = GetComponent<Light2D>();
        }

        if (lyhty == null)
        {
            lyhty = Lyhty.instance;
        }
    }

    void Update()
    {
        if (lyhty == null) return;

        bool hasFuel = lyhty.currentFuel > 0f;

        if (realLight != null) realLight.enabled = hasFuel;
        if (secondaryLight != null) secondaryLight.enabled = hasFuel;
        if(Animator != null) Animator.SetActive(hasFuel);

        if (!hasFuel)
        {
            lastBrightnessLevel = -1;
            return;
        }

        if (lyhty.brightnessLevel != lastBrightnessLevel)
        {
            lastBrightnessLevel = lyhty.brightnessLevel;
            UpdateLights(lastBrightnessLevel);
        }
    }

    private void UpdateLights(int level)
    {
        Sprite targetSprite = null;
        float targetIntensity = midIntensity;
        float targetRadius = midRadius;

        switch (level)
        {
            case 1:
                targetSprite = lyhty.dimSprite;
                targetIntensity = dimIntensity;
                targetRadius = dimRadius;
                break;
            case 2:
                targetSprite = lyhty.midSprite;
                targetIntensity = midIntensity;
                targetRadius = midRadius;
                break;
            case 3:
                targetSprite = lyhty.brightSprite;
                targetIntensity = brightIntensity;
                targetRadius = brightRadius;
                break;
        }

        
        if (realLight != null && targetSprite != null)
        {
            realLight.lightCookieSprite = targetSprite;
        }

      
        if (secondaryLight != null)
        {
            secondaryLight.intensity = targetIntensity;
            secondaryLight.pointLightOuterRadius = targetRadius;
        }
    }
}
