using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRock : MonoBehaviour
{
    public RubyController player;
    public Rigidbody2D rb;
    public LayerMask collisionLayer;
    public LayerMask playerLayer;
  
   

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

                if (player.CheckMixture().mixtureType == Mixture.MixtureType.Strength)
                {
                    if (IsPushable(transform.position))
                    {
                         rb.MovePosition(rb.position + player.input * player.moveSpeed * Time.fixedDeltaTime * 12);
                    }

                }

        }

    }

    


     private bool IsPushable(Vector3 targetPos)
    {
        
        if (Physics2D.OverlapCircle(targetPos, 0.6f, collisionLayer) != null)
        {
            Debug.Log("not pushable");
            gameObject.layer = 8;
            return false;
           
        }
        return true;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
   
        if (Physics2D.OverlapCircle(transform.position, 1.3f, playerLayer) != null)
        {
          
            if (player.CheckMixture().mixtureType == Mixture.MixtureType.Strength & IsPushable(transform.position)    )
            {
                gameObject.layer = 0;
            }
            else
            {
                gameObject.layer = 8;
            }
        }
    }
}
