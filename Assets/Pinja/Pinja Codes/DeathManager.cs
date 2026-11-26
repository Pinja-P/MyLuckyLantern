using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Death;
    public Transform respawnPoint;

    public Lepakko_chase lepakko;
    public PlayerMovement playerMov;
    public Kamera CameraScript;

    float lastDeathTime;

    public GameObject DeathScreen;

    private void Awake()
    {
        Death = this;
        DeathScreen.SetActive(false);
    }


     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Death") && !playerMov.batCarry && Time.time - lastDeathTime > 1)
         {
            Debug.Log("You Died By Fox");

            DeathScreen.SetActive(true); // Makes death screen menu visible

            transform.position = respawnPoint.position; // Moves player to checkpoint

            lastDeathTime = Time.time;
        }

         if (collision.CompareTag("Death") && playerMov.batCarry && Time.time - lastDeathTime > 1)
         {
            Debug.Log("You Died By Bat");

            playerMov.batCarry = false;  // Resets bat stuff
            lepakko.StopChasing();

            DeathScreen.SetActive(true); // Makes death screen menu visible

            CameraScript.StartCamera();  // Makes camera follow player
            transform.position = respawnPoint.position; // Moves player to checkpoint

            lastDeathTime = Time.time;
         }
    } 

    // Button for death menu
    public void OnClickTryAgain()
    {
        DeathScreen.SetActive(false); // Makes death screen menu invisble
    }

}
