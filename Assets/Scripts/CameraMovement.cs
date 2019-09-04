using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Header("Position variables")]
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    [Header("Animator")]
    public Animator anim;

    [Header("Position reset")]
    public VectorValue camMin;
    public VectorValue camMax;


	// Use this for initialization
	void Start () {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;
        anim = GetComponent<Animator>();
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}

    // LateUpdate is called after all Update functions have been called. 
    //This is useful to order script execution. For example a follow camera 
    //should always be implemented in LateUpdate because it tracks objects that 
    //might have moved inside Update.
    void LateUpdate () {
		if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            //LERP
            //Linearly interpolates between the vectors a and b by the interpolant t
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
	}

    public void BeginKick()
    {
        anim.SetBool("isKicking", true);
        StartCoroutine(KickCo());
    }

    public IEnumerator KickCo()
    {
        yield return null;
        anim.SetBool("isKicking", false);
    }
}
