using UnityEngine;

public class Kettu : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float waitTime = 2f; // kuinka kauan kettu odottaa

    public GameObject PointA;
    public GameObject PointB;

    public bool patrol = true;
    public bool Chase = false;

    private Transform currentTarget;
    private float waitCounter; // laskee kuinka kauan kettu on odottanut

    void Start()
    {
        currentTarget = PointB.transform;
        waitCounter = waitTime;
    }

    void Update()
    {
        if (patrol)
        {
            
            if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
            {
          
                waitCounter -= Time.deltaTime;

              
                if (waitCounter <= 0f)
                {
                    if (currentTarget == PointB.transform)
                    {
                        currentTarget = PointA.transform;
                    }
                    else
                    {
                        currentTarget = PointB.transform;
                    }

                    waitCounter = waitTime; 
                }
            }
            else
            {
              
                transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
