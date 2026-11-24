using UnityEngine;

using System.Collections;


public class trigger_area : MonoBehaviour
{
    public GameObject LepakkoPrefab;
    public GameObject LepakkoSpawn;
    public GameObject GoAwayBat;
    public Lepakko_chase Lepakko;

   
    public float spawnCooldown = 10.0f; 

    private bool HasSpawned = false;

    void Start()
    {
        if (GoAwayBat == null)
        {
            Transform goAwayTransform = transform.Find("GoAwayBat");
            if (goAwayTransform != null)
            {
                GoAwayBat = goAwayTransform.gameObject;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!HasSpawned && other.CompareTag("Player"))
        {
            StartCoroutine(SpawnWithTimer(other.transform));
        }
    }

    private IEnumerator SpawnWithTimer(Transform playerTransform)
    {
        HasSpawned = true;

        var spawnedObj = Instantiate(LepakkoPrefab, LepakkoSpawn.transform.position, Quaternion.identity);

        if (spawnedObj.TryGetComponent(out Lepakko_chase batScript))
        {
            Lepakko = batScript;
            Lepakko.StartChasing(playerTransform, GoAwayBat);
        }

        
        yield return new WaitForSeconds(spawnCooldown);

        HasSpawned = false;
    }
}