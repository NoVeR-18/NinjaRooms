using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int positionOfPatrol;
    [SerializeField]
    private Transform point;
    [SerializeField]
    private bool moveInRight;
    
    Transform player;
    [SerializeField]
    private float stoppingDistance;


    [SerializeField]
    bool chill;
    [SerializeField]
    bool angry;
    [SerializeField]
    bool goback;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if(Vector2.Distance(transform.position, player.position) < stoppingDistance )
        {
            angry = true;
            chill = false;
            goback = false;
        }
        
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goback = true;
            angry = false;
        }
        if (chill == true)
            Chill();
        else if (angry == true)
            Angry();
        else if (goback == true)
            GoBack();
    }


    void Chill()
    {
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            moveInRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveInRight = true;
        }

        if (moveInRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

}