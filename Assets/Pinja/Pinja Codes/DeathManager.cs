using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Death;
    public Transform respawnPoint;

    public Lepakko_chase lepakko;
    public PlayerMovement playerMov;
    public Kamera CameraScript;

    float lastDeathTime;

    private void Awake()
    {
        Death = this;
    }


     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Death") && !playerMov.batCarry && Time.time - lastDeathTime > 2)
         {
            Debug.Log("You Died By Fox");
             transform.position = respawnPoint.position;

            lastDeathTime = Time.time;
         }
         if (collision.CompareTag("Death") && playerMov.batCarry && Time.time - lastDeathTime > 2)
         {
            Debug.Log("You Died By Bat");
            playerMov.batCarry = false;
            lepakko.StopChasing();
            CameraScript.StartCamera();
            transform.position = respawnPoint.position;

            lastDeathTime = Time.time;
         }
    } 

}
