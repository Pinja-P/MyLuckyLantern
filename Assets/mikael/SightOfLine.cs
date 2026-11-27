using System.Collections;
using UnityEngine;

public class SightOfLine : MonoBehaviour
{
    public Kettu KettuScript;
    public float KeepChasingTimer = 2f;

    private Coroutine stopChaseCoroutine;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
       
            if (stopChaseCoroutine != null)
            {
                StopCoroutine(stopChaseCoroutine);
                stopChaseCoroutine = null;
            }

            KettuScript.StartChasing(collision.transform);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            stopChaseCoroutine = StartCoroutine(StopChasingAfterDelay());
        }
    }

    private IEnumerator StopChasingAfterDelay()
    {
        yield return new WaitForSeconds(KeepChasingTimer);
        KettuScript.StopChasing();
        stopChaseCoroutine = null;
    }
}