using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour {

    [SerializeField] private float damage;
    [SerializeField] private string otherTag;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(otherTag) && collider.isTrigger)
        {
            GenericHP temp = collider.GetComponent<GenericHP>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }
}
