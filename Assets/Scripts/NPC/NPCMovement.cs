using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : Interactable {

    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    private float moveTimeSeconds;
    private float waitTimeSeconds;
    private bool isMoving;

    public Collider2D boundsCollider;
    public float speed;
    public float minMoveTime;
    public float maxMoveTime;
    public float minWaitTime;
    public float maxWaitTime;

    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        boundsCollider = GetComponent<Collider2D>();
        ChangeDirection();
    }

    void Update()
    {
        if (isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds <= 0)
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
                
            }
            if (!playerInRange)
            {
                Move();
            }
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
            }
        }
       
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (boundsCollider.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }
    
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Walking to the right
                directionVector = Vector3.right;
                break;
            case 1:
                // Walking up
                directionVector = Vector3.up;
                break;
            case 2:
                // Walking Left
                directionVector = Vector3.left;
                break;
            case 3:
                // Walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("moveY", directionVector.y);
        anim.SetFloat("moveX", directionVector.x);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
       ChooseDifferentDirection();
    }
}
