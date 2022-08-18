using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //inventory
    [SerializeField] private UI_Inventory uiInventory; 
    protected Inventory inventory;
    private InventoryMixing mix;
    private Mixture mixture;
    
  
   
    public Rigidbody2D rb;
    public Animator animator;
    private AudioSource footstep;

    //Movement
    public float moveSpeed = 3.25f;
    public Vector2 input;
    private bool isMoving;
    public LayerMask collisionLayer;
    public bool canMove;
    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        footstep = GetComponent<AudioSource>();
        canMove = true;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        //zdobycie mix  i ustawienie w clasie InventoryMixing playera
        mix = uiInventory.SendMixReference();
        mix.SetPlayer(this);
        mixture = new Mixture(Mixture.MixtureType.Zadna);
        //transform.position = startingPosition.initialValue;
    }

    //przy kolizji z obiektami ktore maja w�aczone is trigger
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    

    // Update is called once per frame
    void Update()
    {

        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }


        if (!isMoving )
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            //usuniecie chodzenie po skosie
            if (input.x != 0) input.y = 0;


            if (input != Vector2.zero )
            {
                animator.SetFloat("Horizontal", input.x);
                animator.SetFloat("Vertical", input.y);
               
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
           
        }




        animator.SetFloat("Speed", input.sqrMagnitude);
    }
    IEnumerator Move(Vector3 targetPos)
    {
         
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private bool IsWalkable(Vector3 targetPos)
    {

        if (Physics2D.OverlapCircle(targetPos, 0.15f, collisionLayer) != null )
        {
            return false;
        }

        
        return true;
    }
    void FootStep()
    {
        footstep.Play();
    }


    public void UseMixture(Mixture mixture)
    {

        this.mixture = mixture;
        Debug.Log("mikstura playera" + this.mixture.ToString());

    }
    public Mixture CheckMixture()
    {
        return this.mixture;
    }

}
