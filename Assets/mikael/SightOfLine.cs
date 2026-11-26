using UnityEngine;

public class SightOfLine : MonoBehaviour
{
    public Kettu KettuScript;








   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            KettuScript.StartChasing(collision.transform);
        }

        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KettuScript.StopChasing();
        }
    }
}
