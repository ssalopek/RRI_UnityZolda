using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pushable : MonoBehaviour {

    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private float pushWait;
    Vector3 pushFromPosition;
    bool isPushed = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !isPushed)
        {
            pushFromPosition = collider.transform.position;
            StartCoroutine(PushCo());
            isPushed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isPushed = false;
            StopAllCoroutines();
        }
    }

    private Vector3 LRUD(Vector3 positionOne, Vector3 positionTwo)
    {
        float diffy = positionOne.y - positionTwo.y;
        float diffx = positionOne.x - positionTwo.x;
        if(Mathf.Abs(diffy) > Mathf.Abs(diffx))
        {
            if(diffy > 0)
            {
                return new Vector3(0,1,0);  
            }
            else
            {
                return new Vector3(0, -1, 0);
            }
        }
        else
        {
            if (diffx > 0)
            {
                return new Vector3(1, 0, 0);
            }
            else
            {
                return new Vector3(-1, 0, 0);
            }
        }
    }

    private IEnumerator PushCo()
    {
        yield return new WaitForSeconds(pushWait);
        Push(LRUD(transform.position, pushFromPosition));
    } 

    void Push(Vector3 pushDirection)
    {
        myRigidbody.DOMove(transform.position + pushDirection, 0.3f);
    }
}
