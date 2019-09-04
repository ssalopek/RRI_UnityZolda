using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkelf : Skeleton {

    public GameObject fireball;
    public float fireDelay;
    public bool canFire = true;

    private float fireDelaySeconds;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if(fireDelaySeconds <= 0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                            transform.position) <= chaseRadius
           && Vector3.Distance(target.position,
                               transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.standing
                && currentState != EnemyState.stagger)
            {
                if (canFire)
                {
                    Vector3 tempVector = target.transform.position - transform.position;
                    GameObject current = Instantiate(fireball, transform.position, Quaternion.identity);
                    current.GetComponent<Projectiles>().Launch(tempVector);
                    canFire = false;
                    ChangeAnima(tempVector - transform.position);
                    ChangeState(EnemyState.standing);
                    anim.SetBool("wakeUp", true);
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
            anim.SetBool("wakeDown", true);
        }
    }

    public void ChangeAnima(Vector2 direction)
    {
        direction = direction.normalized;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                Debug.Log("DESNO");
                anim.SetBool("idleRight", true);
                anim.SetBool("idleLeft", false);
                anim.SetBool("idleUp", false);
                anim.SetBool("idleDown", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.standing);
            }
            else if (direction.x < 0)
            {
                Debug.Log("LIJEVO");
                anim.SetBool("idleLeft", true);
                anim.SetBool("idleRight", false);
                anim.SetBool("idleUp", false);
                anim.SetBool("idleDown", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.standing);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                Debug.Log("GORE");
                anim.SetBool("idleUp", true);
                anim.SetBool("idleRight", false);
                anim.SetBool("idleLeft", false);
                anim.SetBool("idleDown", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.standing);
            }
            else if (direction.y < 0)
            {
                Debug.Log("DOLJE");
                anim.SetBool("idleDown", true);
                anim.SetBool("idleRight", false);
                anim.SetBool("idleLeft", false);
                anim.SetBool("idleUp", false);
                anim.SetBool("wakeDown", false);
                ChangeState(EnemyState.standing);
            }
        }
    }

}
