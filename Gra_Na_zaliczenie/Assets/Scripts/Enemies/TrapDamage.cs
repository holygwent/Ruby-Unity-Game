using System;
using System.Collections;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{

    [SerializeField] private float damage;
    private BoxCollider2D coll2D;
    protected AudioSource hurt;
    // [SerializeField] private float SpikeCoolDown;
    // private Animator anim;
    

    private void Start()
    {
        coll2D = GetComponent<BoxCollider2D>();
        coll2D.enabled = false;
        hurt = GetComponent<AudioSource>();
    }

    // private void Awake()
    // {
    //     collider2D.enabled = false;
    // }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (collider.GetComponent<Health>().dead == false)
            {
                hurt.Play();
            }
            collider.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void DamageDisabled()
    {
        coll2D.enabled = false;
    }

    public void DamageEnabled()
    {
        coll2D.enabled = true;
    }
    
}