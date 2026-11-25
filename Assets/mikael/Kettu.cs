using UnityEngine;

public class Kettu : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float waitTime = 2f; // kuinka kauan kettu odottaa

    public GameObject PointA;
    public GameObject PointB;
    public GameObject FOV;
    public GameObject targetPlayer;

    public bool patrol = true;
    public bool Chase = false;
   


    private Transform currentTarget;
    private Transform playerTransform;
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

                    MoveAndRotateTowards(currentTarget.position, moveSpeed);
                }
        }

        else if (Chase && targetPlayer != null)
        {
            MoveAndRotateTowards(targetPlayer.transform.position, moveSpeed * 2);

            

        }




        void MoveAndRotateTowards(Vector2 targetPos, float speed)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

           
            if (targetPos.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            }
            else if (targetPos.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); 
            }
        }
    }
    public void StartChasing(Transform player)
    {
        Chase = true;
        patrol = false;
        targetPlayer = player.gameObject;
        currentTarget = playerTransform;
    }

    public void StopChasing()
    {
       
        Chase = false;
        patrol = true;
        targetPlayer = null;
        waitCounter = waitTime;
        float distToA = Vector2.Distance(transform.position, PointA.transform.position);
        float distToB = Vector2.Distance(transform.position, PointB.transform.position);

        currentTarget = (distToA < distToB) ? PointA.transform : PointB.transform;
    }



}

