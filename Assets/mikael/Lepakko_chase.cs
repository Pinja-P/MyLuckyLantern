using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Lepakko_chase : MonoBehaviour
{
    public float speed = 3f;
    
    
    private bool isChasing = false;
    private bool isStopped = false;
    public GameObject targetPlayer;
    public GameObject goAwayBat;
    public bool carryingPlayer;


    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
      
        

    }

    void Update()
    {
        if (isChasing && targetPlayer != null)
        {
            CheckLanter();
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
        
            if(carryingPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, goAwayBat.transform.position, speed * Time.deltaTime);
            }
        }
       if (isStopped)
        {
            transform.position = Vector2.MoveTowards(transform.position,goAwayBat.transform.position, speed * Time.deltaTime);
            
            if(Vector2.Distance(transform.position, goAwayBat.transform.position) < 0.1f)
            {
                Destroy(gameObject);
            }

        }
    }

    public void StartChasing(Transform player, GameObject exitpoint)
    {
        goAwayBat = exitpoint;
        if (Lyhty.instance != null && Lyhty.instance.brightnessLevel >= 3)
        {
            StopChasing();
            return;
        }
        isStopped = false;
        targetPlayer = player.gameObject;
        isChasing = true;
        
    }

    private void CheckLanter()
    {
        if (Lyhty.instance != null && Lyhty.instance.brightnessLevel >= 3)
        {
            StopChasing();
        }
    }

 
    public void StopChasing()
    {
        isChasing = false;
        targetPlayer = null;
        isStopped = true;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (!carryingPlayer && collision.gameObject.tag == "Player")
        {
            carryingPlayer = true;
            collision.gameObject.GetComponent<PlayerMovement>().batCarry = true;
            collision.gameObject.GetComponent<PlayerMovement>().batCarrier = gameObject;


            Debug.Log("Player collided with Lepakko");
        }
    }
}