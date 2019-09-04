using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;

    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        //anim.SetBool("wakeUp", true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckDistance();
	}

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && 
            Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
            anim.SetBool("wakeDown", true);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    public void ChangeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                Debug.Log("DESNO");
               SetAnimFloat(Vector2.right);
               anim.SetBool("moveRight", true);
                anim.SetBool("moveLeft", false);
                anim.SetBool("moveUp", false);
                anim.SetBool("moveDown", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.walk);
            }
            else if(direction.x < 0)
            {
                Debug.Log("LIJEVO");
                SetAnimFloat(Vector2.left);
                anim.SetBool("moveLeft", true);
                anim.SetBool("moveRight", false);
                anim.SetBool("moveUp", false);
                anim.SetBool("moveDown", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.walk);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                Debug.Log("GORE");
               SetAnimFloat(Vector2.up);
                anim.SetBool("moveUp", true);
                anim.SetBool("moveRight", false);
                anim.SetBool("moveLeft", false);
                anim.SetBool("moveDown", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.walk);
            }
            else if (direction.y < 0)
            {
                Debug.Log("DOLJE");
               SetAnimFloat(Vector2.down);
                anim.SetBool("moveDown", true);
                anim.SetBool("moveRight", false);
                anim.SetBool("moveLeft", false);
                anim.SetBool("moveUp", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.walk);
            }
        }
    }

    
}
