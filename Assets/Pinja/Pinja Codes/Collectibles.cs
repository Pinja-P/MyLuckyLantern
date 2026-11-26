using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    private int pineconeCounter;
    public TMP_Text counterText;
    public GameObject AcornCounter;

    private void Start()
    {
        AcornCounter.SetActive(false);
    }


    // Pinecone collectables
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Käpy") && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            pineconeCounter += 1;
            counterText.text = "Pinecones: " + pineconeCounter + "/10";
            AcornCounter.SetActive(true);
        }
    }

}
