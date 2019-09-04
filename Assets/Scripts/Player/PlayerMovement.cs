using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk, attack, interact, stagger, idle
}

public class PlayerMovement : MonoBehaviour {

    public int speed;
    public PlayerState currentState;
    public VectorValue startingPosition;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;


    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    
    public Inventory playerInventory;
    public GameObject inventoryCanvas;
    private bool isInventoryOpen;

    public SpriteRenderer recievedItemSprite;
    public Signal playerHit;

    public Color flashColor;
    public Color defaultColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;

    public Signal decreaseArrow;

    public AudioSource swingAudio;
    public AudioSource arrowAudio;
    public AudioSource hurtAudio;
    
    [Header("Projectiles")]
    public GameObject projectile;
    public Item bow;

    // Use this for initialization
    void Start () {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentState == PlayerState.interact)
        {
            return;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("inventory"))
        {
            isInventoryOpen = !isInventoryOpen;
            if (isInventoryOpen)
            {
                inventoryCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                inventoryCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        if (Input.GetButtonDown("attack") 
            && currentState != PlayerState.attack 
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
            swingAudio.Play();
        }
        else if (Input.GetButtonDown("fire")
            && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            if (playerInventory.CheckForItem(bow))
            {
                StartCoroutine(FireCo());
                
            }
            
        }

        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
	}

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null; //wait for 1 frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator FireCo()
    {
        currentState = PlayerState.attack;
        yield return null; //wait for 1 frame
        MakeArrow();
        yield return new WaitForSeconds(.33f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void MakeArrow()
    {
        if(playerInventory.currentArrows > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Setup(temp, ChooseArrowDirection());
            playerInventory.ReduceArrows(arrow.arrowCost);
            decreaseArrow.Raise();
            arrowAudio.Play();
        }
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX"))*Mathf.Rad2Deg;
        return new Vector3(0,0,temp);
    }

    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("recieveItem", true);
                currentState = PlayerState.interact;
                recievedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("recieveItem", false);
                currentState = PlayerState.idle;
                recievedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }   
        }

        
    }

    void MoveCharacter()
    {
        
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    } 

    public void Knock(float knockTime, float damage)
    {
       // StartCoroutine(KnockCo(knockTime));
        
        currentHealth.RunTimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RunTimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        
        playerHit.Raise();
        if (myRigidbody != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            //enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator FlashCo()
    {
        hurtAudio.Play();
        int temp = 0;
        triggerCollider.enabled = false;
        while(temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = defaultColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
        
    }


}
